using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.HttpServer.Tools;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer {
    class NenecchiHttpServer {
        private bool                RunServer = true;
                                    
        private string              ServerLocation;
        private string              ServerLocationNoPort;
        private string              ReplacingUrl = "http://osu.ppy.sh";

        private static HttpListener Listener;

        private Thread              MonitorThread;

        private MySqlCtx            MySqlConnectionData;

        public NenecchiHttpServer(string location, MySqlCtx mysql_connectiondata, bool autorun) {
            this.ServerLocation = location;
            this.ServerLocationNoPort = "http://" + UrlParseUtils.ParseUntil(ServerLocation.Replace("http://",""), ':');
            this.MySqlConnectionData = mysql_connectiondata;

            Listener = new HttpListener();
            Listener.Prefixes.Add(ServerLocation);
            Listener.Start();

            RouteList.Init();

            if (autorun) {
                MonitorThread = new Thread(Monitor.MonitorStats.Monitoring);
                ListenForConnections();
            }
                
        }

        public void ListenForConnections() {

            MonitorThread.Start();
            Console.WriteLine("Listening");

            while (RunServer) {
                HttpListenerContext  ctx = Listener.GetContext();

                HttpListenerRequest  req = ctx.Request;
                HttpListenerResponse rsp = ctx.Response;

                if (req.HttpMethod == "GET") { 
                    string DictionaryKey = UrlParseUtils.ParseUntil(req.Url.ToString(), '?').Replace(ServerLocationNoPort, "").Replace(ReplacingUrl, "");
                    string GetString = "";
                    try {
                        GetString = req.Url.ToString().Replace(UrlParseUtils.ParseUntil(req.Url.ToString(), '?'), "").Remove(0, 1);
                    }catch {
                        //No Get Params Given
                    }

                    byte[] Response = new byte[0];

                    try {
                        Func<Params, MySqlCtx, byte[]> HandleFunction = Routes.RouteList[DictionaryKey].Handle;
                        Response = HandleFunction(new Params(GetParams.GetGetParamsFromString(GetString)), MySqlConnectionData);

                    }
                    catch {
                        //No Route
                        Response = Encoding.UTF8.GetBytes("404");

                    }


                    rsp.OutputStream.Write(Response, 0, Response.Length);
                    rsp.Close();
                }else if(req.HttpMethod == "POST") {
                    string DictionaryKey = UrlParseUtils.ParseUntil(req.Url.ToString(), '?').Replace(ServerLocationNoPort, "").Replace(ReplacingUrl, "");
                    string GetString = "";

                    try {
                        GetString = req.Url.ToString().Replace(UrlParseUtils.ParseUntil(req.Url.ToString(), '?'), "").Remove(0, 1);
                    }
                    catch {
                        //No Get Params Given
                    }

                    byte[] Response = new byte[0];

                    try {
                        Func<Params, MySqlCtx, byte[]> HandleFunction = Routes.RouteList[DictionaryKey].Handle;


                        byte[] BinaryPostData;

                        using(MemoryStream ms = new MemoryStream()) {
                            req.InputStream.CopyTo(ms);
                            BinaryPostData = ms.ToArray();
                        }

                        Response = HandleFunction(new Params(GetParams.GetGetParamsFromString(GetString), BinaryPostData), MySqlConnectionData);

                    }
                    catch (Exception e){
                        Console.WriteLine(e.Message);
                        Response = Encoding.UTF8.GetBytes("404");

                    }

                    rsp.OutputStream.Write(Response, 0, Response.Length);
                    rsp.Close();


                }


            }

            MonitorThread.Join();
        }
    }
}
