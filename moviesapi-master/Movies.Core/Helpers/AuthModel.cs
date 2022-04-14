using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Helpers
{
   public class AuthModel
    {
        public User User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
