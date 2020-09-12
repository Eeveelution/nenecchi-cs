using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.Handlers {

    class osu_getreplay {
        public static byte[] Handle(Params p, MySqlCtx ctx) {
            return File.ReadAllBytes("testoffset.bin");
        }
    }
}
