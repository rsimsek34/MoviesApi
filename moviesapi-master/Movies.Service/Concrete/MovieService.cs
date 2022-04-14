using Microsoft.EntityFrameworkCore;
using Movies.Data.Context;
using Movies.Data.Entities;
using Movies.Service.Abstract;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Service.Concrete
{
    public class MovieService : IMovieService
    {

        private const string URL = "https://api.themoviedb.org/3/movie/";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MovieDbContext _movieDbContext;
       
        //Refactor edilmeli...
        public MovieService(IHttpClientFactory httpClientFactory,MovieDbContext movieDbContext) { _httpClientFactory = httpClientFactory; _movieDbContext = movieDbContext; }

        public async Task<MovieDetail> AddMovieDetail(MovieDetail movieDetail)
        {
            await _movieDbContext.MovieDetail.AddAsync(movieDetail);
            _movieDbContext.SaveChanges();
            return movieDetail;
        }

        public async Task<IEnumerable<MovieDetail>> EvulationMovieDetails(int movieId)
        {
            return await _movieDbContext.MovieDetail.Where(x => x.MovieId == movieId).ToListAsync();

        }

        public async Task<object> MovieDetail(int movieId)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(URL);
            var uri = movieId+ "?api_key=8f2b963b6286a69bddb8921591b2213f&language=en-US&append_to_response=videos,details,similar,credits,recommendations";
            var result = await httpClient.GetStringAsync(uri);
            return JObject.Parse(result);
        }

        public async Task<object> PopularMovies(string page=null)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(URL);
            var uri = "popular?api_key=8f2b963b6286a69bddb8921591b2213f&language=en-US&page=" + page + "";
            var result = await httpClient.GetStringAsync(uri);

            return JObject.Parse(result);
        }

        public async Task<object> TopMovies(string page = null)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(URL);
            var uri = "top_rated?api_key=8f2b963b6286a69bddb8921591b2213f&language=en-US&page=" + page + "";
            var result = await httpClient.GetStringAsync(uri);

            return JObject.Parse(result);
        }

        public async Task<object> UpcoimngMovies(string page = null)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(URL);
            var uri = "upcoming?api_key=8f2b963b6286a69bddb8921591b2213f&language=en-US&page=" + page + "";
            var result = await httpClient.GetStringAsync(uri);

            return JObject.Parse(result);
        }
    }
}
