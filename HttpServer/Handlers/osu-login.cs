using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer.Handlers {
    class osu_login {
        public static byte[] Handler(Params p, MySqlCtx ctx) { 
            string SQL = "SELECT * FROM users WHERE username=@user AND password=@pass";

            NameValueCollection bindings = new NameValueCollection();

            bindings.Add("@user", p.GetGetParams()["username"]);
            bindings.Add("@pass", p.GetGetParams()["password"]);

            NameValueCollection z = MySqlCommandHandler.Select(ctx, SQL, bindings);
            if(z.Count == 9) { return Encoding.UTF8.GetBytes("1"); }
            else { return Encoding.UTF8.GetBytes("0"); }
        }
    }
}
