using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_2022_
{
 
    internal class DB
    {
        public static string Connect = "Host=localhost;User id=postgres;Password=228522245;Database=NEWS;Port=2285;";
        //INSERT info
        public static bool DATABASE_INSERT(string name, string create, string CONNECTION, string cmd,Data obj)
        {
            try
            {
                using (var conn = new NpgsqlConnection(CONNECTION))
                {
                    conn.Open();
                    CREATE_TABLE(create, conn);
                    if (DATABASE_READ(conn, $"SELECT title FROM {name}", obj.title))
                    {
                        conn.Open();
                        using (var command = new NpgsqlCommand(cmd, conn))
                        {
                            command.Parameters.AddWithValue("id", DATABASE_READ(CONNECTION, $"SELECT COUNT(*) FROM {name};") + 1);
                            command.Parameters.AddWithValue("title", obj.title);
                            command.Parameters.AddWithValue("info", obj.info);
                            command.Parameters.AddWithValue("time", obj.time);
                            command.Parameters.AddWithValue("link", obj.link);
                            command.Parameters.AddWithValue("image", obj.image);
                            command.ExecuteNonQuery();

                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception exp) { Console.WriteLine(exp.Message); return false; }
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
            catch (Exception exp) { Console.WriteLine(exp.Message); return 0; }

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
            catch (Exception exp) { Console.WriteLine(exp.Message); return false; }
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
        public static bool CREATE_TABLE(string cmd, NpgsqlConnection conn)
        {
            try
            {
                using (var command = new NpgsqlCommand(cmd, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exp) { Console.WriteLine(exp.Message); return false; }
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
                            Console.WriteLine("\n" + title);
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