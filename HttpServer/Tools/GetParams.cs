using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer.Tools {
    class GetParams {
        public static NameValueCollection GetGetParamsFromString(string UriAfterQuestionMark) {
            if (UriAfterQuestionMark == "")
                return null;
            NameValueCollection ret = new NameValueCollection();

            string[] Parsed1 = UriAfterQuestionMark.Split('&');

            foreach (string s in Parsed1) {
                string[] Parsed = s.Split('=');

                ret.Add(Parsed[0], Parsed[1]);
            }

            return ret;
        }
    }
}
