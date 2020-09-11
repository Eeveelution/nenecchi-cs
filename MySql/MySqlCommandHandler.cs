using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.MySql {
    class MySqlCommandHandler {
        public static NameValueCollection[] Select(MySqlCtx ctx, string sql, NameValueCollection bindings) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            foreach (string key in bindings) {
                Command.Parameters.AddWithValue(key, bindings[key]);
            }

            try {
                Connection.Open();
            }
            catch (Exception e) {
                throw e;
            }


            List<NameValueCollection> ret = new List<NameValueCollection>();

            using (MySqlDataReader reader = Command.ExecuteReader()) {

                while (reader.Read()) {
                    NameValueCollection current = new NameValueCollection();
                    for (int col = 0; col < reader.FieldCount; col++) {
                        switch (reader.GetFieldType(col).ToString()) {
                            case "System.Int32":
                                current.Add(reader.GetName(col).ToString(), reader.GetInt32(col).ToString());
                                break;
                            case "System.String":
                                current.Add(reader.GetName(col).ToString(), reader.GetString(col));
                                break;
                            case "System.Double":
                                current.Add(reader.GetName(col).ToString(), reader.GetDouble(col).ToString());
                                break;
                        }
                    }
                    ret.Add(current);

                }


            }
            return ret.ToArray();
        }


        public static NameValueCollection[] Select(MySqlCtx ctx, string sql) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            

            try {
                Connection.Open();
            }
            catch (Exception e) {
                throw e;
            }

            List<NameValueCollection> ret = new List<NameValueCollection>();

            using (MySqlDataReader reader = Command.ExecuteReader()) {
                
                while (reader.Read()) {
                    NameValueCollection current = new NameValueCollection();
                    for(int col = 0; col < reader.FieldCount; col++) {
                        switch (reader.GetFieldType(col).ToString()) {
                            case "System.Int32":
                                current.Add(reader.GetName(col).ToString(), reader.GetInt32(col).ToString());
                                break;
                            case "System.String":
                                current.Add(reader.GetName(col).ToString(), reader.GetString(col));
                                break;
                            case "System.Double":
                                current.Add(reader.GetName(col).ToString(), reader.GetDouble(col).ToString());
                                break;
                        }
                    }
                    ret.Add(current);
                }

                
            }
            return ret.ToArray();
        }

        public static void Insert(MySqlCtx ctx, string sql) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            Command.ExecuteNonQuery();
        }

        public static void Insert(MySqlCtx ctx, string sql, NameValueCollection bindings) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            try {
                Connection.Open();
            }
            catch (Exception e) {
                throw e;
            }

            foreach (string key in bindings) {
                Command.Parameters.AddWithValue(key, bindings[key]);
            }
            Command.ExecuteNonQuery();
        }

    }
}
