using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.MySql {
    class MySqlCtx {
        private string Location, Username, Password, Database;

        public MySqlCtx(string location, string username, string password, string database) {
            this.Location = location;
            this.Username = username;
            this.Password = password;
            this.Database = database;
        }

        public string GetConnectionString() {
            return String.Format("server={0};userid={1};password={2};database={3}",
                    this.Location, this.Username, this.Password, this.Database
                );
        }
    }
}
