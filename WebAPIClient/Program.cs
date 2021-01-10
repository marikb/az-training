using System;
using MySql.Data.MySqlClient;

namespace Version
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=server-asafsqldemo-new.mysql.database.azure.com;userid=asaf@server-asafsqldemo-new;password=bogdanbogdan1!;database=demodatabase";

            using var con = new MySqlConnection(cs);
            con.Open();

            Console.WriteLine($"MySQL version : {con.ServerVersion}");
        }
    }
}