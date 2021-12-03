using System;
using System.Data.SqlClient;
using System.Text;
using cervezarteamdelta.Models;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "validationpaas.database.windows.net"; 
                builder.UserID = "rootvali";            
                builder.Password = "Password1234";     
                builder.InitialCatalog = "validation-paas";

                List<Codes> listCodes = new List<Codes>();
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    String sql = "SELECT * FROM Codes";                    

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Codes codes = new Codes();
                                codes.Code = Convert.ToInt32(reader[0]);
                                codes.Email = reader[1].ToString();
                                codes.User = reader[2].ToString();
                                codes.Name = reader[3].ToString();
                                codes.Check_Used = Convert.ToBoolean(reader[4]);

                                if(reader[5] != DBNull.Value){
                                    codes.Date_asignment = Convert.ToDateTime(reader[5]);
                                }                                
                                listCodes.Add(codes);
                            }
                        }
                    }                    
                }
                foreach(Codes c in listCodes){
                    Console.WriteLine(c.Code);
                    //Console.WriteLine("{0} {1}", c.Code, c.Check_Used);
                }
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine(); 
        }
    }
}