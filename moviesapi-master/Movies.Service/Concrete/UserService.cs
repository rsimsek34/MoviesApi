using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Movies.Core.Helpers;
using Movies.Data.Context;
using Movies.Data.Entities;
using Movies.Service.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly MovieDbContext _movieDbContext;
        private  readonly AppSettings _appSettings;
        public UserService(MovieDbContext movieDbContext, IOptions<AppSettings> appSettings) 
        {
            _appSettings = appSettings.Value;
            _movieDbContext =movieDbContext ?? throw new ArgumentNullException("MovieDbContext can not be null"
            );
         
        }
        public  async Task<User> AddUser(User user)
        {
            
                await _movieDbContext.User.AddAsync(user);
                _movieDbContext.SaveChanges();
                return user;
            
        }

        public AuthModel Authenticate(string userName)
        {
            var user = _movieDbContext.User.FirstOrDefault(x => x.Username == userName);
            if (user == null) throw new NullReferenceException("");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            AuthModel authModel = new AuthModel();
            authModel.User = user;
            authModel.Token = tokenHandler.WriteToken(token);
            
            return authModel;
        }
    }
}
