using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs {
    class Program {
        static void Main(string[] args) {
            nenecchi_cs.HttpServer.NenecchiHttpServer server 
                = new HttpServer.NenecchiHttpServer(
                    "http://127.0.0.1:80/", 
                    new MySqlCtx(
                        "localhost","root","","yunchan"),true);
        }
    }
}
