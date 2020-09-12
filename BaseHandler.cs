using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs {
    class BaseHandler {
        public static byte[] Handle(Params p, MySqlCtx ctx) {
            return new byte[1];
        }
    }
}
