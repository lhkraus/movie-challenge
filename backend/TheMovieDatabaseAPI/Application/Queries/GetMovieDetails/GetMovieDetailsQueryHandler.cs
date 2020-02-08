using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Client;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsViewModel>
    {
        private readonly ITMDbClient _client;

        public GetMovieDetailsQueryHandler(ITMDbClient client)
        {
            _client = client;
        }

        public async Task<MovieDetailsViewModel> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
        {
            var movieDetails = await _client.GetMovieDetailsAsync(movieId: request.Id);
            var movieDetailsViewModel = movieDetails.ToObject<MovieDetailsViewModel>();

            return movieDetailsViewModel;
        }
    }
}
