using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer {
    class Routes {
        public static Dictionary<string, RouteHandler> RouteList = new Dictionary<string, RouteHandler>();

        public static void AddRoute(string location, Func<Params, MySqlCtx, byte[]> handler, string method) {
            RouteList.Add(location, new RouteHandler(handler));
        }
    }
}
