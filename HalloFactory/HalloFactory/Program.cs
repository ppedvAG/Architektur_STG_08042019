using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            using (SqlConnection con = new SqlConnection(sqlConString))
            {
                con.Open();
                Console.WriteLine("Datenbankverbindung wurde hergestellt");

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM Employees";

                    using (SqlDataReader reader = cmd.ExecuteReader())
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
