using System.Data.SqlClient;
using cervezarteamdelta.Models;
namespace cervezarteamdelta.DAC{
    class GetData
    {
        public List<int> GetDataCodesFromUser(string user)
        {
            List<int> listCodes = new List<int>();
            try 
            {                
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                //TODO: La configuración se guarda en el entorno.
                builder.DataSource = "validationpaas.database.windows.net"; 
                builder.UserID = "rootvali";            
                builder.Password = "Password1234";     
                builder.InitialCatalog = "validation-paas";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    String sql = "SELECT code FROM Codes WHERE user = " + user;

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                listCodes.Add(Convert.ToInt32(reader[0]));
                            }
                        }
                    }
                }
            }

            catch
            {
                //TODO: Auditar si falla: se tendría que enviar a un log los fallos
            }
            
            return listCodes;
        }
        public Boolean InsertDataInCode(string user){
            
            return true;
        }
    }

}

