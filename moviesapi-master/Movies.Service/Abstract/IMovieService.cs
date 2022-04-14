using Movies.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Service.Abstract
{
    public interface IMovieService
    {
        Task<object> PopularMovies(string page =null);
        Task<object> UpcoimngMovies(string page = null);
        Task<object> TopMovies(string page = null);
        Task<object> MovieDetail(int movieId);
        Task<IEnumerable<MovieDetail>> EvulationMovieDetails(int movieId);
        Task<MovieDetail> AddMovieDetail(MovieDetail movieDetail);

    }
}
