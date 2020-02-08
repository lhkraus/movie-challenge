using MediatR;
using System.Collections.Generic;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetUpcomingMoviesQuery : IRequest<IList<UpcomingMovieViewModel>>
    {
        public int Page { get; }

        public GetUpcomingMoviesQuery(int page)
        {
            Page = page;
        }
    }
}
