﻿using Npgsql;

namespace Parser_2022_
{

    internal class DB
    {
        public static string Connect = "Host=localhost;User id=postgres;Password=228522245;Database=NEWS;Port=2285;";









        //INSERT info
        //public static bool DATABASE_TEST(string value)
        //{
        //    string cmd = $"INSERT INTO time (date) VALUES (@date)";

        //    try
        //    {
        //        using (var conn = new NpgsqlConnection(Connect))
        //        {
        //            conn.Open();
        //            using (var command = new NpgsqlCommand(cmd, conn))
        //            {
        //                command.Parameters.AddWithValue("date", DateTime.ParseExact(value, "dd.M.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
        //                command.ExecuteNonQuery();

        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception exp) {  return false; }
        //    return true;
        //}
        public static bool DATABASE_INSERT(string name, string CONNECTION, string cmd, Data obj)
        {
            try
            {
                using (var conn = new NpgsqlConnection(CONNECTION))
                {
                    conn.Open();
                    CREATE_TABLE(name, conn);
                    if (DATABASE_READ(conn, $"SELECT title FROM {name}", obj.title))
                    {
                        conn.Open();
                        using (var command = new NpgsqlCommand(cmd, conn))
                        {
                            command.Parameters.AddWithValue("id", DATABASE_READ(CONNECTION, $"SELECT COUNT(*) FROM {name};") + 1);
                            command.Parameters.AddWithValue("title", obj.title);
                            command.Parameters.AddWithValue("info", obj.info);
                            command.Parameters.AddWithValue("time", DateTime.ParseExact(obj.time, "dd.M.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture));
                            command.Parameters.AddWithValue("link", obj.link);
                            command.Parameters.AddWithValue("image", obj.image);
                            command.ExecuteNonQuery();

                        }
                        conn.Close();
                    }
                }
            }
            catch { return false; }
            return true;
        }
        /*
         
          
         
               (
                )
               (
        /\  .-"""-.  /\
       //\\/  ,,,  \//\\
       |/\| ,;;;;;, |/\|
       //\\\;-"""-;///\\
      //  \/   .   \/  \\
     (| ,-_| \ | / |_-, |)
       //`__\.-.-./__`\\
      // /.-(() ())-.\ \\
     (\ |)   '---'   (| /)
      ` (|           |) `
        \)           (/
         


         
         */

        public static void DATABASE_SORT(string name)
        {
            try
            {
                var cmd = $"SELECT time FROM {name} ORDER BY time DESC;";
                using (var conn = new NpgsqlConnection(Connect))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(cmd, conn))
                    {
                        Console.WriteLine(command.CommandText);
                        command.ExecuteNonQuery();
                        // DATABASE_UPDATE(values, name, conn);
                    }
                    conn.Close();
                }
            }
            catch (Exception exp) { Console.Write(exp.Message); }

        }
        public static void DATABASE_UPDATE(NpgsqlDataReader values, string name, NpgsqlConnection conn)
        {
            try
            {
                int counter = 1;
                while (values.Read())
                {
                    using (var connection = new NpgsqlConnection(Connect))
                    {
                        string cmd = $"UPDATE {name} SET time=@time,link=@link,image=@image,info=@info,title=@title WHERE id=@id;";
                        connection.Open();
                        //var a = 
                        using (var command = new NpgsqlCommand(cmd, connection))
                        {
                            //var a = DateTime.Parse((DateTime.Parse(values["time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                            command.Parameters.AddWithValue("id", counter++);
                            command.Parameters.AddWithValue("title", values["title"]);
                            command.Parameters.AddWithValue("info", values["info"]);
                            command.Parameters.AddWithValue("time", values["time"]);
                            command.Parameters.AddWithValue("link", values["link"]);
                            command.Parameters.AddWithValue("image", values["image"]);

                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
            }
            catch { return; }
        }
        //count
        public static int DATABASE_READ(string CONNECTION, string cmd)
        {
            try
            {
                using (var conn = new NpgsqlConnection(CONNECTION))
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
            catch (Exception exp) { return 0; }

        }
        /*
         
                  .
                 ":"
               ___:____      |"\/"|
              ,'        `.    \  /
              |  O        \___/  |
            ~^~^~^~^~^~^~^~^~^~^~^~^~

        */
        //Check(if the title is in regions table)
        public static bool DATABASE_READ(NpgsqlConnection CONNECTION, string cmd, string title)
        {
            try
            {

                using (NpgsqlCommand command = new NpgsqlCommand(cmd, CONNECTION))
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
            catch (Exception exp) { return false; }
            CONNECTION.Close();
            return true;
        }
        /*

                         _,.-------------.._
                      ,-'        j          `-.
                    ,'        .-'               `.
                   /          |                   '
                  /         ,-'                    `
                 .         j                         \
                .          |                          \
                : ._       |   _....._                 .
                |   -.     L-''       `.               :
                | `.  \  .'             `.             |
               /.\  `, Y'                 :           ,|
              /.  :  | \                  |         ,' |
             \.    " :  `\                |      ,--   |
              \    .'     '-..___,..      |    _/      :
               \  `.      ___   ...._     '-../        '
             .-'    \    /| \_/ | | |      ,'         /
             |       `--' |    '' |'|     /         .'
             |            |      /. |    /       _,'
             |-.-.....__..|        `...:...--'''
             |_|_|_L.L.T._/     |
             \_|_|_L.T-''/      |
              |                /
             /             _.-'
             :         _..'
             \__...--''

         */
        public static bool CREATE_TABLE(string name, NpgsqlConnection conn)
        {
            string cmd = $"CREATE TABLE IF NOT EXISTS public.{name}\r\n(\r\n    id integer NOT NULL,\r\n    title text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    \"time\" timestamp without time zone NOT NULL,\r\n    info text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    link text COLLATE pg_catalog.\"default\" NOT NULL,\r\n    image text COLLATE pg_catalog.\"default\" NOT NULL\r\n)\r\n\r\nTABLESPACE pg_default;\r\n\r\nALTER TABLE IF EXISTS public.{name}\r\n    OWNER to postgres;";
            try
            {
                using (var command = new NpgsqlCommand(cmd, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp) { return false; }
            return true;
        }
        /*
         
                                                     ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣴⣶⡶⠶⠶⠶⠿⠿⠿⠿⠶⠶⣶⣦⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀                                            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣾⡿⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⣷⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀                                            ⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣶⠿⠟⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢿⣦⣄⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀                                            ⠀⠀⠀⢀⣤⡾⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⢦⡀⠀⠀⠀⠀
⠀                                            ⠀⠀⠀⠀⢠⣶⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣷⡄⠀⠀⠀
                                            ⠀⠀⠀⢀⣼⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣆⠀⠀
                                            ⠀⠀⣠⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣦⠀
                                            ⠀⢀⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣦⡀⠀⠀⠀⠀⠀⠀⠀⠈⣿⡆
                                            ⠀⣾⡟⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠸⣷
                                            ⢰⣿⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⢻
                                            ⢸⡏⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⢸
                                            ⣾⡇⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⢸
                                            ⣿⡇⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⢸
                                            ⢿⡇⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡈⠙⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⣾
                                            ⢸⣇⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⠏⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠒⠶⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿
                                            ⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⣤⡾⢡⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠏
⠀                                            ⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠏⠀
⠀                                            ⠸⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⠏⠀⠀
⠀⠀                                            ⠻⣷⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡟⠃⠀⠀⠀
⠀⠀                                            ⠀⠻⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡿⠋⠀⠀⠀⠀⠀
⠀⠀⠀                                            ⠀⠹⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠋⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀                                           ⠈⠻⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⠿⠏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀                                          ⠉⠛⠿⢶⣦⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡴⢿⣿⣥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                                     ⠀ ⠀⠀⢉⣻⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠀⠀⠀⠁⠀⠀⠉⠛⢷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                                     ⠀⢀⣤⣶⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣦⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀                                      ⠀⠀⠀⣠⣴⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠙⣷⡄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀                                     ⠀⢀⣾⠟⠁⠀⠀⠀⢀⣀⣤⡤⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡀⠀⠀⠀⠈⢿⣆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀                                     ⠘⣿⣶⣶⠶⠿⠟⢻⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⣦⣀⠀⠀⠈⢻⡇⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀⠀        ⠀⠀⠀⢀⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡏⠻⠿⢶⣶⡾⠇⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀        ⠀⠀⢸⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀        ⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀⠀        ⢸⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀        ⠘⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣶⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀       ⠀⠸⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀⠀       ⠀⠘⢿⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⣺⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                              ⠀⠀⠀       ⠀⠀⠉⠛⠿⢶⣶⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                ⠀⠈⠻⣶⣤⡀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                         ⠀⠀⠀⠀⠀⠀          ⠀⠀⠀⢀⣤⡿⢿⣤⡀⠀⠀⠀⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                         ⠀⠀⠀⠀⠀          ⠀⠀⠀⢠⣿⡏⠀⠀⠙⠧⠀⠀⣴⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                        ⠀⠀⠀⠀⠀⠀⠀           ⠀⢻⣷⣤⡀⠀⣀⣴⡾⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                                   ⠀⠀⢰⡿⠛⢿⣷⡄⠀⠈⠙⠛⠛⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                          ⠀⠀⠀         ⠀⠸⣷⣄⠀⠘⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠀                        ⠀⠀⠀          ⠌⣿⣇⣰⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                         ⠀⠀⠀          ⠀⠀⠉⠛⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                        ⠀⠀⠀⠀     ⠀⠀⣰⡶⣶⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀        ⠀⠀⠀⠀⠀⠀                        ⠀⠀⠀⠀     ⠀⠀⠹⣶⡾⠇
  
         
         
         
         
         */
        //Check(if the title is in regions table)
        public static bool DATABASE_CHECK(string title, string CONN, string name)
        {

            try
            {
                using (var conn = new NpgsqlConnection(CONN))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand($"SELECT title FROM {name} WHERE title='{title}'", conn))
                    {
                        NpgsqlDataReader read = cmd.ExecuteReader();
                        read.Read();

                        if (title == read[0].ToString())
                        {
                            conn.Close();
                            return true;
                        }
                    }
                    conn.Close();
                }
            }
            catch { return false; }
            return false;
        }

    }
}
//$"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{name}'";