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
        public Boolean InsertDataInCode(Codes codes)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            bool finalExec = false;

            //TODO: La configuración se guarda en el entorno.
            builder.DataSource = "validationpaas.database.windows.net"; 
            builder.UserID = "rootvali";            
            builder.Password = "Password1234";     
            builder.InitialCatalog = "validation-paas";
            

            using(SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {                
                using(SqlCommand command = connection.CreateCommand())
                {
                    //TODO: si existe hace el update
                    command.CommandText = "UPDATE Codes SET Email = @email, [User] = @user, [Name] = @name, Check_Used = 1, Date_asignment =  @date_asignement Where Code = @code";

                    command.Parameters.AddWithValue("@code", codes.Code);
                    command.Parameters.AddWithValue("@email", codes.Email);
                    command.Parameters.AddWithValue("@name", codes.Name);
                    command.Parameters.AddWithValue("@user", codes.User);
                    command.Parameters.AddWithValue("@check_used", 1);
                    command.Parameters.AddWithValue("@date_asignement", codes.Date_asignment);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if(result < 0){
                        finalExec = false;
                    }
                    else
                    {
                        finalExec= true;
                    }                        
                }
            }
            return finalExec;
        }
    }

}

