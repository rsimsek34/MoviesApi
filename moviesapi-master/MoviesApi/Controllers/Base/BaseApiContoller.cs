using Microsoft.AspNetCore.Mvc;
using Movies.Core.Generics;

namespace MoviesApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiContoller : ControllerBase
    {
        [NonAction]
        protected IActionResult Success(ApiResponse data)
        {
            return Ok(data);
        }
        [NonAction]
        protected IActionResult Success<T>(ApiResponse<T> data)
        {
            return Ok(data);
        }

        [NonAction]
        protected IActionResult Success(string message)
        {
            return Success(new ApiResponse
            {
                Success = true,
                Message = message
            });
        }

        [NonAction]
        protected IActionResult Success<T>(string message, T data)
        {
            return Success(new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult Created<T>(string message, T data)
        {
            return Created(new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult Created<T>(ApiResponse<T> data)
        {
            return StatusCode(201, data);
        }
        [NonAction]
        protected IActionResult NoContent<T>(string message, T data)
        {
            return NoContent(new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult NoContent<T>(ApiResponse<T> data)
        {
            return StatusCode(204, data);
        }
        [NonAction]
        protected IActionResult BadRequest<T>(string message, T data)
        {
            return BadRequest(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult BadRequest<T>(ApiResponse<T> data)
        {
            return StatusCode(400, data);
        }
        [NonAction]
        protected IActionResult Forbidden<T>(string message, T data)
        {
            return Forbidden(new ApiResponse<T> { 
            Success = false,
            Message = message,
            Data = data
            });
        }
        [NonAction]
        protected IActionResult Forbidden<T>(ApiResponse<T> data)
        {
            return StatusCode(403, data);
        }

        [NonAction]
        protected IActionResult NotFound<T>(string message, T data)
        {
            return NotFound(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = data
            });
        }
        [NonAction]
        protected IActionResult NotFound<T>(ApiResponse<T> data)
        {
            return StatusCode(404, data);
        }
        [NonAction]
        protected IActionResult Error<T>(string message, T data)
        {
            return Error(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = data

            });
        }
        protected IActionResult Error<T>(ApiResponse<T> data)
        {
            return StatusCode(500, data);
        }
    }
}
