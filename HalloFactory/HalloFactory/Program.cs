using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Factory");

            var sqlConString = "Server=.;Database=Northwind;Trusted_Connection=true;";
            var sqLiteConString = @"Data Source=..\..\..\Northwind.sqlite";
            string conString;
            DbProviderFactory factory = null;
            if (DateTime.Now.DayOfWeek != DayOfWeek.Monday)
            {
                factory = new SQLiteFactory(); // dies ist eine zeile c# code
                conString = sqLiteConString;
            }
            else
            {
                factory = SqlClientFactory.Instance;
                conString = sqlConString;
            }


            using (DbConnection con = factory.CreateConnection())
            {
                con.ConnectionString = conString;
                con.Open();
                Console.WriteLine("Datenbankverbindung wurde hergestellt");

                using (DbCommand cmd = factory.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Employees";

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
                        }
                    }
                }
            }//con.Close();

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
