using System.Data.SqlClient;

namespace your_Review
{

    public static class SQL
    {

        public static void AddToList(Reviews todo)
        { if (todo.Title != null && todo.Status != null && todo.Genre != null && todo.Score == null && todo.image != null) {

                string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";

                SqlConnection conn = new SqlConnection(connectionString);

                string sql = $@"INSERT INTO Moviesandseries ( [Title] ,      [Genre] ,       [Score] ,      [Status] ,     [Image] ,       [CreatedTime] )
                                  VALUES ('{todo.Title}','{todo.Genre}','{todo.Score}','{todo.Status}','{todo.image}','{todo.CreatedTime}')";

                SqlCommand command = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                conn.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
            } 
            else
            {
                MessageBox.Show("Please Enter A Value", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static List<Reviews> getmylist ()
        {    
           List<Reviews> reviews= new List<Reviews>();

            string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";

            SqlConnection  conn = new SqlConnection(connectionString);

            string sql = $@"SElECT [ID], [Title] ,      [Genre] ,       [Score] ,      [Status] ,     [Image] ,       [CreatedTime] 
                           From  [YourReview].[dbo].[Moviesandseries]  ";

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
                temp.CreatedTime = Convert.ToDateTime(reader["CreatedTime"]);
                
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
        public static void updatelist(int Id)
        {
           string connectionString = @"Server=.\SQLExpress;Database=YourReview;Trusted_Connection=True";
            
            SqlConnection conn = new SqlConnection(connectionString);
            
            string sql = $@"UPDATE Moviesandseries  SET [Title]= [Title]  , [Genre]=[Genre] , [Score]=[Score]  , [Status]=[Status] , [Image]=[Image] , [CreatedTime]=[CreatedTime] 
                                                       where [Id] = {Id}";
                                          
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
