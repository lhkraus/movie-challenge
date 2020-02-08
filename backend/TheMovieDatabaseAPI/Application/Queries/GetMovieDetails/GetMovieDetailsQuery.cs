using MediatR;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetMovieDetailsQuery : IRequest<MovieDetailsViewModel>
    {
        public int Id { get; }

        public GetMovieDetailsQuery(int id)
        {
            Id = id;
        }
    }
}
