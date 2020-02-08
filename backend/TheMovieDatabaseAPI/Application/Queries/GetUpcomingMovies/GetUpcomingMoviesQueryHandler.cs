using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Client;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetUpcomingMoviesQueryHandler : IRequestHandler<GetUpcomingMoviesQuery, IList<UpcomingMovieViewModel>>
    {
        private readonly ITMDbClient _client;

        public GetUpcomingMoviesQueryHandler(ITMDbClient client)
        {
            _client = client;
        }

        public async Task<IList<UpcomingMovieViewModel>> Handle(GetUpcomingMoviesQuery request, CancellationToken cancellationToken)
        {
            var upcomingMovies = await _client.GetUpcomingMoviesAsync(request.Page);
            var upcomingMoviesViewModel = upcomingMovies["results"]
                .ToObject<IList<UpcomingMovieViewModel>>();

            return upcomingMoviesViewModel;
        }
    }
}
