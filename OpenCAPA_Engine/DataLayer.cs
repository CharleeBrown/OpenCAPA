using Microsoft.Data.SqlClient;


namespace OpenCAPA_Engine
{
    public class DataLayer
    {
  
        public void AddComment(string Comment, int CAPA_ID)
        {
            // Connection String
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    // Opening the connection, creating the command, adding parameters.
                    conn.Open();
                    SqlCommand comms = new SqlCommand();
                    comms.Connection = conn;
                    comms.CommandText = @"INSERT INTO CAPA_COMMENTS VALUES (@CAPA, @Comment_)";
                    comms.Parameters.AddWithValue("@CAPA", CAPA_ID);
                    comms.Parameters.AddWithValue("@Comment_", Comment);
          
                    // Executing the insert query.
                    comms.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    // Closing the connection.
                    conn.Close();
                }

            }


        }
        
        
        public void CreateCapaItem(string Title, string Description)
        {
            // Grabbing the connection string
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            // Initializing the CAPA ID return variable
            int returnCAPA = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                 // Creating the command, inserting into the table   
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

                    // While the connection is still open, execute this query.
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
                catch (Exception ex) 
                {
                    Console.Write(ex.Message);
                }
                
                    conn.Close();
                               
            }
           

        }

        public void LoadCapaItem(string Title, string Description)
        {
            // Grabbing the connection string
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            // Initializing the CAPA ID return variable
            int returnCAPA = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                try
                {
                    // Creating the command, inserting into the table   
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

                    // While the connection is still open, execute this query.
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
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

                conn.Close();

            }


        }


    }
}
