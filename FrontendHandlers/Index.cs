using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.FrontendHandlers {
    class Index {
        public static byte[] Handle(Params p, MySqlCtx ctx) {
            return Encoding.UTF8.GetBytes("Frontend Test");
        }
    }
}
