using System;
using System.Runtime.Intrinsics.X86;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Renci.SshNet;


namespace TerraNova3
{
    

    public class DatabaseHelper
    {
        public void SaveValues(string value1, string value2, string value3)
        {
            var server = "pat.infolab.ecam.be:62201";
            var sshUserName = "admin-3be";
            var sshPassword = "chill1012269";
            var databaseUserName = "root";
            var databasePassword = "";
            
            var sshClient = new SshClient(server, sshUserName, sshPassword);
            sshClient.Connect();
            
            using (sshClient)
            {
                MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Port = 3306,
                    UserID = databaseUserName,
                    Password = databasePassword,
                    Database = "terranova",
                };

                //using var conn = new MySqlConnection(csb.ConnectionString);
                try
                {
                    //conn.Open();

                    
                    //string query = "INSERT INTO game  VALUES (plant, herbivore, carnivore)";
                    //MySqlCommand cmd = new MySqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("plant", value1);
                    //cmd.Parameters.AddWithValue("herbivore", value2);
                    //cmd.Parameters.AddWithValue("carnivore", value3);
                    //cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    //Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    //conn.Close();
                    sshClient.Disconnect();
                }
            }
        }
    }

}

