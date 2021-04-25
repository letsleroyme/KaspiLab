using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KaspiBdAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathtodb = @"C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA";

            //string connectionstring = $@"Data Source=localhost\\SQLEXPRESS;AttachDbFilename={pathtodb};Initial Catalog=kaspilab;User ID=testuser;Password=qwerty12";
            string connectionstring = $@"Data Source=.\SQLEXPRESS;Initial Catalog=kaspilab;Integrated Security=false;User ID=testuser; Password=qwerty12";

            string Sql = $@"select ag.DateFrom, pr.Title, acc.Balance from dbo.Client c
left join kaspilab.dbo.Agreement ag on (ag.id = c.AgreementID)
left join kaspilab.dbo.Document doc on (doc.ID = c.DocumentID)
left join kaspilab.dbo.TypeOfProduct pr on (pr.ID = ag.ProductID)
left join kaspilab.dbo.AccountNumber acc on (acc.ID = c.AccountNumberID)
where doc.DocNumber = {1}";


            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(Sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.ReadLine();
            }


        }





    }
}
