using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.MySql {
    class MySqlCommandHandler {
        /*public static NameValueCollection Select(MySqlCtx ctx, string sql, NameValueCollection bindings) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            foreach(string key in bindings) {
                Command.Parameters.AddWithValue(key, bindings[key]);
            }

            try {
                Connection.Open();
            }catch(Exception e) {
                throw e;
            }

            MySqlDataReader Reader = Command.ExecuteReader();
            return Reader.ToString();

        }*/
        public static NameValueCollection Select(MySqlCtx ctx, string sql, NameValueCollection bindings) {
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


            NameValueCollection ret = new NameValueCollection();

            using (MySqlDataReader reader = Command.ExecuteReader()) {

                while (reader.Read()) {
                    for (int col = 0; col < reader.FieldCount; col++) {
                        switch (reader.GetFieldType(col).ToString()) {
                            case "System.Int32":
                                ret.Add(reader.GetName(col).ToString(), reader.GetInt32(col).ToString());
                                break;
                            case "System.String":
                                ret.Add(reader.GetName(col).ToString(), reader.GetString(col));
                                break;
                            case "System.Double":
                                ret.Add(reader.GetName(col).ToString(), reader.GetDouble(col).ToString());
                                break;
                        }
                    }

                }


            }
            return ret;
        }


        public static NameValueCollection Select(MySqlCtx ctx, string sql) {
            MySqlConnection Connection = new MySqlConnection(ctx.GetConnectionString());

            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = sql;

            

            try {
                Connection.Open();
            }
            catch (Exception e) {
                throw e;
            }


            NameValueCollection ret = new NameValueCollection();

            using (MySqlDataReader reader = Command.ExecuteReader()) {
                
                while (reader.Read()) {
                    for(int col = 0; col < reader.FieldCount; col++) {
                        switch (reader.GetFieldType(col).ToString()) {
                            case "System.Int32":
                                ret.Add(reader.GetName(col).ToString(), reader.GetInt32(col).ToString());
                                break;
                            case "System.String":
                                ret.Add(reader.GetName(col).ToString(), reader.GetString(col));
                                break;
                            case "System.Double":
                                ret.Add(reader.GetName(col).ToString(), reader.GetDouble(col).ToString());
                                break;
                        }
                    }

                }

                
            }
            return ret;
        }

    }
}
