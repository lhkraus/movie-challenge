namespace TheMovieDatabaseAPI.Application.Queries
{
    public class SearchedMoviesViewModel
    {
        public string Title { get; }
        public string Poster { get; }
        public int[] Genres { get; }
        public string ReleaseDate { get; }

        public SearchedMoviesViewModel(
            string title,
            string poster_path,
            int[] genre_ids,
            string release_date)
        {
            Title = title;
            Poster = poster_path;
            Genres = genre_ids;
            ReleaseDate = release_date;
        }
    }
}
