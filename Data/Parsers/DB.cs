using Npgsql;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using OwlNews.Models;
using System.Linq.Expressions;

namespace Parser_2022_
{

    internal class DB
    {

        //"Server=owlnews2.postgres.database.azure.com;Database=owlnews;Port=5432;User Id=vbakosh;Password=OwlDBNews!;Ssl Mode=VerifyFull;";
        public static string Connect = "Host=localhost;User id=postgres;Password=228522245;Database=NEWS;Port=2285;";
        public static string name_all = "all_news";
        public static string name_sources = "sources";
        public static string name_regions = "regions";

        public async static Task DATABASE_INSERT(Data obj)
        {

            string cmd = $"INSERT INTO {name_all} (title,info,time,link,image,id,region_id,source_id )" +
                $" VALUES (@title,@info,@time,@link,@image,@id,@region_id,@source_id)";
            
            try
            {
                if (DATABASE_CHECK(obj)) { return; }
                using (var conn = new NpgsqlConnection(Connect))
                {
                    conn.Open();
                    CREATE_TABLE(conn, obj);

                    DATABASE_INSERT_SOURCE(obj);

                    conn.Open();
                    await using (var command = new NpgsqlCommand(cmd, conn))
                    {

                        command.Parameters.AddWithValue("id", DATABASE_READ(Connect, $"SELECT COUNT(*) FROM {name_all};") + 1);
                        command.Parameters.AddWithValue("title", obj.title);
                        command.Parameters.AddWithValue("info", obj.info);
                        try
                        {
                            command.Parameters.AddWithValue("time", DateTime.ParseExact(obj.time, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                        }
                        catch
                        {
                            command.Parameters.AddWithValue("time", DateTime.ParseExact(obj.time, "MM.dd.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                        }
                        command.Parameters.AddWithValue("link", obj.link);
                        command.Parameters.AddWithValue("image", obj.image);
                        command.Parameters.AddWithValue("region_id", obj.region);
                        command.Parameters.AddWithValue("source_id", obj.source_id);

                        await command.ExecuteNonQueryAsync();
                    }
                    conn.Close();
                    
                }

            }
            catch {}
            return;
        }

        private static void DATABASE_INSERT_SOURCE(Data obj)
        {
            string cmd = $"INSERT INTO {name_sources} (source_id,source_logo) VALUES (@source_id,@source_logo);";
            using (var conn = new NpgsqlConnection(Connect))
            {
                if (DATABASE_READ(Connect, $"SELECT COUNT(*) FROM {name_sources} WHERE source_id='{obj.source_id}';") > 0) { return; }
                conn.Open();
                using (var command = new NpgsqlCommand(cmd, conn))
                {
                    command.Parameters.AddWithValue("source_logo", obj.source_logo);
                    command.Parameters.AddWithValue("source_id", obj.source_id);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        //count
        public static int DATABASE_READ(string Connect, string cmd)
        {
            try
            {
                using (var conn = new NpgsqlConnection(Connect))
                {
                    conn.Open();

                    using (var command = new NpgsqlCommand(cmd, conn))
                    {
                        var count = command.ExecuteReader();
                        count.Read();
                        int counter = Convert.ToInt32(count[0].ToString());
                        conn.Close();
                        return counter;
                    }
                }
            }
            catch { return 0; }

        }
        //Check(if the title is in regions table)
        public static bool DATABASE_READ(NpgsqlConnection Connect, string cmd, string title)
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(cmd, Connect))
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (title == reader[0].ToString())
                        {
                            return false;
                        }
                    }
                }
            }
            catch { return false; }
            Connect.Close();
            return true;
        }
        public static bool CREATE_TABLE(NpgsqlConnection conn, Data obj)
        {
            List<string> cmd = new()
            {
                 $"CREATE TABLE IF NOT EXISTS public.{name_regions}\r\n(\r\n    region_id integer NOT NULL,\r\n    region_name text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT regions_pkey PRIMARY KEY (region_id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.{name_regions}\r\n    OWNER to \"vbakosh\";"
                ,$"CREATE TABLE IF NOT EXISTS public.{name_sources}\r\n(\r\n    source_id integer NOT NULL,\r\n    source_logo text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    CONSTRAINT sources_pkey PRIMARY KEY (source_id)\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.{name_sources}\r\n    OWNER to \"vbakosh\";"
                ,$"CREATE TABLE IF NOT EXISTS public.\"{name_all}\"\r\n(\r\n    id integer NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" timestamp without time zone NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    region_id integer,\r\n    source_id integer,\r\n    CONSTRAINT all_region_id_fkey FOREIGN KEY (region_id)\r\n        REFERENCES public.regions (region_id) MATCH SIMPLE\r\n        ON UPDATE NO ACTION\r\n        ON DELETE NO ACTION,\r\n    CONSTRAINT all_source_id_fkey FOREIGN KEY (source_id)\r\n        REFERENCES public.sources (source_id) MATCH SIMPLE\r\n        ON UPDATE NO ACTION\r\n        ON DELETE NO ACTION\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.\"{name_all}\"\r\n    OWNER to \"vbakosh\";" };
            foreach (var item in cmd)
            {
                try
                {
                    using (var command = new NpgsqlCommand(item, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch { conn.Close(); return false; }
            }
            conn.Close();
            DATABASE_INSERT_REGIONS();
            return true;
        }
        public static void DATABASE_INSERT_REGIONS()
        {
            if (DATABASE_READ(Connect, "SELECT COUNT(*) FROM regions;") == 24) { return; }
            List<string> list = new()
            {
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(1,'Вінницька область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(2,'Волинська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(3,'Дніпропетровська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(4,'Донецька область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(5,'Житомирська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(6,'Закарпатська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(7,'Запорізька область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(8,'Івано-Франківська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(9,'Київська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(10,'Кіровоградська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(11,'Луганська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(12,'Львівська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(13,'Миколаївська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(14,'Одеська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(15,'Полтавська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(16,'Рівненська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(17,'Сумська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(18,'Тернопільська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(19,'Харківська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(20,'Херсонська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(21,'Хмельницька область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(22,'Черкаська область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(23,'Чернівецька область');",
                $"INSERT INTO {name_regions} (region_id,region_name) VALUES(24,'Чернігівська область');"
            };
            foreach (var cmd in list)
            {
                using (var conn = new NpgsqlConnection(Connect))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(cmd, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }
        //Check(if the title is in regions table)
        public static bool DATABASE_CHECK(Data obj)
        {

            try
            {
                using (var conn = new NpgsqlConnection(Connect))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand($"SELECT title FROM {name_all} WHERE title=@title AND region_id=@region_id AND source_id=@source_id;", conn))
                    {
                        cmd.Parameters.AddWithValue("title", obj.title);
                        cmd.Parameters.AddWithValue("source_id", obj.source_id);
                        cmd.Parameters.AddWithValue("region_id", obj.region);

                        NpgsqlDataReader read = cmd.ExecuteReader();

                        read.Read();

                        if (read[0] == obj.title)
                        {
                            Console.WriteLine(true);
                            return true;
                        }

                        conn.Close();
                        Console.WriteLine(true);

                        return true;
                    }
                    
                }
            }
            catch { Console.WriteLine(false.ToString() + "CATCH");  return false; }
        }

    }
}