using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Constants;
using Movies.Core.Generics;
using Movies.Data.Entities;
using Movies.Service.Abstract;
using MoviesApi.Controllers.Base;
using System.Threading.Tasks;



namespace MoviesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseApiContoller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) { _movieService = movieService; }
        // GET: api/<MovieController>

        [HttpGet("popularmovies", Name = "GetPopularMovies")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> PopularMovies(string page = null)
        {
            var result = await _movieService.PopularMovies(page);

            return Success(Messages.Success, result);
        }
        [HttpGet("upcomingmovies", Name = "GetUpComingMovies")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> UpcomingMovies(string page = null)
        {
            var result = await _movieService.UpcoimngMovies(page);
            return Success(Messages.Success, result);
        }
        [HttpGet("topmovies", Name = "GetTopMovies")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> TopMovies(string page = null)
        {
            var result = await _movieService.TopMovies(page);
            return Success(Messages.Success, result);
        }
        [AllowAnonymous]
        [HttpGet("details", Name = "GetMovieDetail")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> MovieDetail(int movieId)
        {
            var result = await _movieService.MovieDetail(movieId);
            return Success(Messages.Success, result);
        }
        [HttpPost("addDetail", Name = "AddMovieDetail")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> AddMovieDetailAsync([FromBody] MovieDetail movieDetail)
        {
            var result = await _movieService.AddMovieDetail(movieDetail);
            return Success(Messages.Success, result);
        }
        [AllowAnonymous]
        [HttpGet("evulationDetails", Name = "GetEvulationDetails")]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), 400)]
        public async Task<IActionResult> EvulationDetails(int movieId)
        {
            var result = await _movieService.EvulationMovieDetails(movieId);
            return Success(Messages.Success, result);
        }


    }
}
