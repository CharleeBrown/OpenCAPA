using Microsoft.Data.SqlClient;
using OpenCAPA;

namespace OpenCAPA_Engine
{
    internal class DataLayer
    {
  
        public void AddComment(string Comment, int CAPA_ID)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {

                    conn.Open();
                    SqlCommand comms = new SqlCommand();
                    comms.Connection = conn;
                    comms.CommandText = @"INSERT INTO CAPA_COMMENTS VALUES (@CAPA, @Comment_)";
                    comms.Parameters.AddWithValue("@CAPA", CAPA_ID);
                    comms.Parameters.AddWithValue("@Comment_", Comment);
          

                    comms.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }


        }
        
        
        public void CreateCapaItem(string Title, string Description)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            int returnCAPA = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    
                    SqlCommand comms = new SqlCommand();

                    comms.Connection = conn;
                    comms.CommandText = @"INSERT INTO CAPA_DATA VALUES (@Title, @Descrip)";
                    comms.Parameters.AddWithValue("@Title", Title);
                    comms.Parameters.AddWithValue("@Descrip", Description);

                    comms.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }

                try
                {
                    SqlCommand CommentCom = new SqlCommand();

                    CommentCom.Connection = conn;
                    CommentCom.CommandText = @"SELECT CAPA_ID FROM CAPA_DATA WHERE DESCRIP = @Descrip";
                    CommentCom.Parameters.AddWithValue("@Descrip", Description);

                    SqlDataReader reader = CommentCom.ExecuteReader();
                    while (reader.Read())
                    {
                        int CAPA = Convert.ToInt32(reader["CAPA_ID"]);
                        returnCAPA = CAPA;
                    }
                    AddComment(Description, returnCAPA);
                }
                finally
                {
                    conn.Close();
                }
               
            }
           

        }




    }
}
