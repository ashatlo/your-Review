using System.Data.SqlClient;
using System.Threading.Tasks;

namespace your_Review
{

    public static class SQL
    {

        public static void AddToList(Reviews todo)
        { 

                string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";

                SqlConnection conn = new SqlConnection(connectionString);

                string sql = $@"INSERT INTO Moviesandseries ( [Title] ,      [Genre] ,       [Score] ,      [Status] ,     [Image] )
                                  VALUES ('{todo.Title}','{todo.Genre}','{todo.Score}','{todo.Status}','{todo.image}')";

                SqlCommand command = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
           
        }
        public static List<Reviews> getmylist ()
        {    
           List<Reviews> reviews= new List<Reviews>();

            string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";

            SqlConnection  conn = new SqlConnection(connectionString);

            string sql = $@"SElECT [ID], [Title] ,      [Genre] ,       [Score] ,      [Status] ,     [Image]  From  [YourReview].[dbo].[Moviesandseries]  ";

            SqlCommand sqlCommand = new SqlCommand(sql,conn);

            conn.Open();
           SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Reviews temp= new Reviews();
                temp.Id     = Convert.ToInt32(reader["ID"]);
                temp.Title  = Convert.ToString(reader["Title"]);
                temp.Genre  = Convert.ToString(reader["Genre"]);
                temp.Score  = Convert.ToInt32(reader["Score"]);
                temp.Status = Convert.ToString(reader["Status"]);
                //fix this
                //temp.image = Image.FromFile("");
                //convert img to Byte[]
                reviews.Add(temp); 

            } 
            conn.Close();

            return reviews;
        }
        public static void dellist(int id)
        {
            string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";

            SqlConnection conn = new SqlConnection(connectionString);
           
            string sql = $@"DELETE FROM Moviesandseries  Where  [Id] = {id} ";

            SqlCommand comm = new SqlCommand(sql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter();

             adapter.DeleteCommand = comm;

             conn.Open();
             adapter.DeleteCommand.ExecuteNonQuery();
             comm.Dispose();
             conn.Close();
        }
        public static void updatelist(Reviews update)
        {
           string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";
            
            SqlConnection conn = new SqlConnection(connectionString);
            
            string sql = $@"UPDATE Moviesandseries  SET  [Title] = '{update.Title}', [Genre] ='{update.Genre}',[Score]='{update.Score}',[Status]='{update.Status}',[Image]='{update.image}'
                        where Id ={update.Id}";
                                          
            SqlCommand command2 = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();

             adapter.UpdateCommand= command2;
             conn.Open();
             adapter.UpdateCommand.ExecuteNonQuery();
             command2.Dispose();
             conn.Close();

        }

    }
}
