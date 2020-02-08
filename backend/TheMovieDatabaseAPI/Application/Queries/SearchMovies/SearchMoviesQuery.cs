using MediatR;
using System.Collections.Generic;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class SearchMoviesQuery : IRequest<IList<SearchedMoviesViewModel>>
    {
        public string Title { get; }

        public SearchMoviesQuery(string title)
        {
            Title = title;
        }
    }
}
