using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer.Objects {
    class RouteHandler {
        
        private Func<Params, MySqlCtx, byte[]> HandleFunction;

        public RouteHandler(Func<Params, MySqlCtx, byte[]> testHandler) {
            this.HandleFunction = testHandler;
        }

        public byte[] Handle(Params p, MySqlCtx ctx) {
            return HandleFunction(p, ctx);
        }
    }
}
