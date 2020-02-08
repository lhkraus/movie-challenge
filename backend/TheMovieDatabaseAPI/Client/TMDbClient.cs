using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;

namespace TheMovieDatabaseAPI.Client
{
    public class TMDbClient : ITMDbClient
    {
        private const string BASE_ENDPOINT = "https://api.themoviedb.org/3";
        private const string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        private readonly HttpClient _httpClient;

        public TMDbClient(HttpClient httpClient)
        {            
            _httpClient = httpClient;
        }

        public async Task<JObject> GetGenres()
        {
            var url = QueryHelpers.AddQueryString($"{BASE_ENDPOINT}/genre/movie/list", "api_key", API_KEY);
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<JObject>();
        }

        public async Task<JObject> GetMovieDetailsAsync(int movieId)
        {
            var url = QueryHelpers.AddQueryString($"{BASE_ENDPOINT}/movie/{movieId}", "api_key", API_KEY);
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<JObject>();
        }

        public async Task<JObject> SearchMovieAsync(string movieTitle)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"api_key", API_KEY },
                {"query", movieTitle },
            };
            var url = QueryHelpers.AddQueryString($"{BASE_ENDPOINT}/search/movie", queryParams);
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<JObject>();
        }

        public async Task<JObject> GetUpcomingMoviesAsync(int page)
        {
            var queryParams = new Dictionary<string, string>()
            {
                {"api_key", API_KEY },
                {"page", page.ToString() },
            };
            var url = QueryHelpers.AddQueryString($"{BASE_ENDPOINT}/movie/upcoming", queryParams);
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<JObject>();
        }
    }
}
