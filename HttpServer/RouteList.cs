using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer {
    class RouteList {
        public static void Init() {
            Routes.AddRoute("/web/osu-login.php", Handlers.osu_login.Handler, "GET");
            Routes.AddRoute("/web/osu-getscores.php", Handlers.osu_getscores.Handle, "GET");
            Routes.AddRoute("/web/osu-submit.php", Handlers.osu_submit.Handle, "GET");
            Routes.AddRoute("/web/osu-getreplay.php", Handlers.osu_getreplay.Handle, "GET");

            Routes.AddRoute("/", FrontendHandlers.Index.Handle, "GET");
        }
    }
}
