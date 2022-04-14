using Movies.Core.Helpers;
using Movies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Abstract
{
  public  interface IUserService
    {
        Task<User> AddUser(User user);
        AuthModel Authenticate(string userName);
    }
}
