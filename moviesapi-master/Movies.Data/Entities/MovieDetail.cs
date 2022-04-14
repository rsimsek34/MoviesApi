using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Entities
{
   public class MovieDetail : BaseEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
    }
}
