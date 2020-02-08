using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace TheMovieDatabaseAPI.Client
{
    public interface ITMDbClient
    {
        Task<JObject> GetUpcomingMoviesAsync(int page);
        Task<JObject> GetMovieDetailsAsync(int movieId);
        Task<JObject> SearchMovieAsync(string title);
        Task<JObject> GetGenres();
    }
}
