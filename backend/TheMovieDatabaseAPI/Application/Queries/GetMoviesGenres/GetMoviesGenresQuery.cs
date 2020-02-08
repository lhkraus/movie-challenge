using MediatR;
using System.Collections.Generic;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class GetMoviesGenresQuery : IRequest<IList<MoviesGenreViewModel>>
    {
        public GetMoviesGenresQuery() { }
    }
}
