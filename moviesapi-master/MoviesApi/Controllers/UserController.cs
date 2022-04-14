using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Helpers;
using Movies.Data.Entities;
using Movies.Service.Abstract;
using MoviesApi.Controllers.Base;
using Movies.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Core.Generics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiContoller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }

        [HttpPost("create",Name ="CreateUser")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var userinfo = await _userService.AddUser(user);
            return Success(Messages.Success, userinfo);
        }
       /// <summary>
       /// Username ile kimlik doğrulaması
       /// </summary>
       /// <param name="authModel">Username</param>
       /// <returns>Token ve user bilgisi</returns>
        
        [HttpPost("authenticate", Name = "AuthenticateUser")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public  IActionResult Authenticate([FromBody]AuthModel authModel)
        {
            var tokeninfo =  _userService.Authenticate(authModel.Username);
            return Success(Messages.Success, tokeninfo);
        }

    }
}
