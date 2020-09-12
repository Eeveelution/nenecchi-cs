using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.HttpServer.Objects {
    class Params {
        private NameValueCollection _GET;
        private byte[]              _POST;

        public Params(NameValueCollection GET) {
            this._GET = GET;
        }
        public Params(byte[] POST) {
            this._POST = POST;
        }
        public Params(NameValueCollection GET, byte[] POST) {
            this._GET = GET;
            this._POST = POST;
        }

        public NameValueCollection GetGetParams() {
            if(_GET != null) {
                return _GET;
            }else {
                throw new Exception("Attempted to Get GET Params when none were Given.");
            }
        }
        public byte[] GetPostParams() {
            if (_POST != null) {
                return _POST;
            }
            else {
                throw new Exception("Attempted to Get POST Params when none were Given.");
            }
        }
    }
}
