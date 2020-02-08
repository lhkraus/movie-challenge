using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Client;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetMoviesGenresQueryHandler : IRequestHandler<GetMoviesGenresQuery, IList<MoviesGenreViewModel>>
    {
        private readonly ITMDbClient _client;

        public GetMoviesGenresQueryHandler(ITMDbClient client)
        {
            _client = client;
        }

        public async Task<IList<MoviesGenreViewModel>> Handle(GetMoviesGenresQuery request, CancellationToken cancellationToken)
        {
            var moviesGenres = await _client.GetMoviesGenres();
            var moviesGenresViewModel = moviesGenres["genres"]
                .ToObject<IList<MoviesGenreViewModel>>();

            return moviesGenresViewModel;
        }
    }
}
