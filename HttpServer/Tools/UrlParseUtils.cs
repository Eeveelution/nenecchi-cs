using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer.Tools {
    class UrlParseUtils {
        public static string ParseUntil(string s, char end) {
            string ret = "";

            try {
                int i = 0;
                while (s[i] != end) {
                    ret += s[i];
                    i++;
                }
            }catch {

            }

            return ret;
        }
        
    }
}
