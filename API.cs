using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Parser_2022_
{

    /*
      _=====_                               _=====_
     / _____ \                             / _____ \
   +.-'_____'-.---------------------------.-'_____'-.+
  /   |     |  '.        S O N Y        .'  |  _  |   \
 / ___| /|\ |___ \                     / ___| /_\ |___ \
/ |      |      | ;  __           _   ; | _         _ | ;
| | <---   ---> | | |__|         |_:> | ||_|       (_)| |
| |___   |   ___| ;SELECT       START ; |___       ___| ;
|\    | \|/ |    /  _     ___      _   \    | (X) |    /|
| \   |_____|  .','" "', |___|  ,'" "', '.  |_____|  .' |
|  '-.______.-' /       \ANALOG/       \  '-._____.-'   |
|               |       |------|       |                |
|              /\       /      \       /\               |
|             /  '.___.'        '.___.'  \              |
|            /                            \             |
 \          /                              \           /
  \________/                                \_________/
                    
     */

    internal class API
    {
        public static string API_Connect = "Host=localhost;User id=postgres;Password=228522245;Database=API;Port=2285;";//Database connection string

        public static void Alarm()
        {
            var url = "https://alerts.com.ua/api/states";//API(all states)

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);//Creating a reguest

            httpRequest.Headers["X-API-Key"] = "";//key
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            string? result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();//geting data
            }
            dynamic my_object = JObject.Parse(result);

            if (!CREATE_TABLE($"CREATE TABLE IF NOT EXISTS public.API\r\n(\r\n    id integer NOT NULL,\r\n    name text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    name_en text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    alert boolean NOT NULL,\r\n    changed text COLLATE pg_catalog.\"default\" NOT NULL\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.API\r\n    OWNER to postgres;",
                        API.API_Connect)) { return; }
            foreach (var region in my_object["states"])
            {
                DATABASE_INSERT(region.GetValue("id").ToString(), region.GetValue("name").ToString(), region.GetValue("name_en").ToString(), region.GetValue("alert").ToString(), region.GetValue("changed").ToString());
            }
        }

        //Add info about a region
        private static void DATABASE_INSERT(string id, string name, string name_en, string alert, string changed)
        {
            try
            {
                using (var conn = new NpgsqlConnection(API.API_Connect))
                {
                    //check if this region exist
                    if (DB.DATABASE_READ(API.API_Connect, $"SELECT COUNT(*) FROM api WHERE name_en='{name_en}';") > 0)
                    {
                        //if yes then we create an UPDATE command 
                        conn.Open();
                        using (var cmd = new NpgsqlCommand($"UPDATE api SET alert = '{bool.Parse(alert)}' WHERE name_en='{name_en}';", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //INSERT command
                        conn.Open();
                        using (var cmd = new NpgsqlCommand($"INSERT INTO api (id,name,name_en,alert,changed ) VALUES (@id,@name,@name_en,@alert,@changed);", conn))
                        {
                            cmd.Parameters.AddWithValue("id", Convert.ToInt32(id));
                            cmd.Parameters.AddWithValue("name", name);
                            cmd.Parameters.AddWithValue("name_en", name_en);
                            cmd.Parameters.AddWithValue("alert", bool.Parse(alert));
                            cmd.Parameters.AddWithValue("changed", changed);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception exp) { Console.Write(exp.Message); return; }
        }
        private static bool CREATE_TABLE(string cmd, string Conn_str)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Conn_str))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(cmd, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception exp) { Console.WriteLine(exp.Message); return false; }
            return true;
        }
    }
}
