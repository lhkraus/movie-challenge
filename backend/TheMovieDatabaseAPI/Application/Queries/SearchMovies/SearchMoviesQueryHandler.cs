using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Client;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class SearchMoviesQueryHandler : IRequestHandler<SearchMoviesQuery, IList<SearchedMoviesViewModel>>
    {
        private readonly ITMDbClient _client;

        public SearchMoviesQueryHandler(ITMDbClient client)
        {
            _client = client;
        }

        public async Task<IList<SearchedMoviesViewModel>> Handle(SearchMoviesQuery request, CancellationToken cancellationToken)
        {
            var searchedMovies = await _client.SearchMovieAsync(title: request.Title);
            var searchedMoviesViewModel = searchedMovies["results"]
                .ToObject<IList<SearchedMoviesViewModel>>();

            return searchedMoviesViewModel;
        }
    }
}
