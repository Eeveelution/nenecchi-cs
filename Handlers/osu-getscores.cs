using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.Handlers {
    class osu_getscores {
        public static byte[] Handle(Params p, MySqlCtx ctx) {
            string SQL = "SELECT * FROM scores WHERE mapmd5=@md5 ORDER BY score DESC";

            NameValueCollection bindings = new NameValueCollection();

            bindings.Add("@md5", p.GetGetParams()["c"]);

            NameValueCollection[] z = MySqlCommandHandler.Select(ctx, SQL, bindings);
            string ret = "";
            foreach(NameValueCollection c in z) {
                ret += String.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}:{8}:{9}:{10}:{11}\n",
                        c["scoreid"], c["username"], c["score"], c["maxcombo"],
                        c["hit50"], c["hit100"], c["hit300"], c["hit0"], c["hitKatu"],
                        c["hitGeki"], c["perfect"], c["mods"]
                    );
            }

            return Encoding.UTF8.GetBytes(ret);
        }
    }
}
