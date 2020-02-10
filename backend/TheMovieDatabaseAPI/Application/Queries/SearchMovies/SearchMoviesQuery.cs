using MediatR;
using System.Collections.Generic;

namespace TheMovieDatabaseAPI.Application.Queries
{
    public class SearchMoviesQuery : IRequest<IList<SearchedMoviesViewModel>>
    {
        public string Title { get; }
        public int Page { get; }

        public SearchMoviesQuery(string title, int page)
        {
            Title = title;
            Page = page;
        }
    }
}
