using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace your_Review
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Score { get; set; }
        public string Status { get; set; }
        public Image image { get; set; }
       // public DateTime CreatedTime { get; set; }
  
        public Reviews()
        {

        }
        public Reviews(string Title, string Genre, int Score, string Status, Image image) 
        {
           
            this.Title = Title;
            this.Genre = Genre; 
            this.Score = Score; 
            this.Status = Status;   
            this.image = image;
        }
        
    }
}
