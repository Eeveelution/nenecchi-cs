using nenecchi_cs.HttpServer.Objects;
using nenecchi_cs.MySql;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nenecchi_cs.Handlers {
    class osu_submit {
        public static byte[] Handle(Params p, MySqlCtx ctx) {
            string SQL = "INSERT INTO scores (scoreid, mapmd5, username, score, performance, maxcombo, hit300, hit100, hit50, hit0, hitGeki, hitKatu, perfect, mods, passed, ranked) VALUES (@scoreid, @mapmd5, @username, @score, @performance, @maxcombo, @hit300, @hit100, @hit50, @hit0, @hitGeki, @hitKatu, @perfect, @mods, @passed, @ranked) ";

            NameValueCollection bindings = new NameValueCollection();

            string[] ParsedScore = p.GetGetParams()["score"].Split(':');

            string MapMD5     = ParsedScore[0];
            string Username   = ParsedScore[1];
            string SubmitHash = ParsedScore[2];
            string Hit300     = ParsedScore[3];
            string Hit100     = ParsedScore[4];
            string Hit50      = ParsedScore[5];
            string HitGeki    = ParsedScore[6];
            string HitKatu    = ParsedScore[7];
            string Hit0       = ParsedScore[8];
            string Score      = ParsedScore[9];
            string MaxCombo   = ParsedScore[10];
            string Perfect    = ParsedScore[11];
            string Grade      = ParsedScore[12];
            string Mods       = ParsedScore[13];
            string Passed     = ParsedScore[14];
            string ScoreID;

            {
                string GetScoreIDSQL = "SELECT * FROM scores";
                NameValueCollection[] z = MySqlCommandHandler.Select(ctx, GetScoreIDSQL);
                ScoreID = z.Length+1.ToString();
            }

            bindings.Add("@scoreid", ScoreID);
            bindings.Add("@mapmd5", MapMD5) ;
            bindings.Add("@username", Username);
            bindings.Add("@score", Score);
            bindings.Add("@performance", 0.0.ToString());
            bindings.Add("@maxcombo", MaxCombo);
            bindings.Add("@hit300", Hit300);
            bindings.Add("@hit100", Hit100);
            bindings.Add("@hit50", Hit50);
            bindings.Add("@hit0", Hit0);
            bindings.Add("@hitGeki", HitGeki);
            bindings.Add("@hitKatu", HitKatu);
            bindings.Add("@perfect", Perfect);
            bindings.Add("@mods", Mods);
            bindings.Add("@passed", Passed);
            bindings.Add("@ranked", "True");

            MySqlCommandHandler.Insert(ctx, SQL, bindings);

            return new byte[1];
        }
    }
}
