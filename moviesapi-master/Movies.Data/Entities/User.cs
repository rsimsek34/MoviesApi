using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Movies.Data.Entities
{
   public class User :BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public ICollection<MovieDetail> MovieDetails { get; set; } = new Collection<MovieDetail>();
    }
}
