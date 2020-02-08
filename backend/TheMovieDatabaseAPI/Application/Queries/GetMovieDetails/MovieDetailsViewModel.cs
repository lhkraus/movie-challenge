namespace TheMovieDatabaseAPI.Application.Queries
{
    public class MovieDetailsViewModel
    {
        public string Title { get; }
        public string Poster { get; }
        public GenresViewModel[] Genres { get; }
        public string Overview { get; }
        public string ReleaseDate { get; }

        public MovieDetailsViewModel(
            string title,
            string poster_path,
            GenresViewModel[] genres,
            string overview,
            string release_date)
        {
            Title = title;
            Poster = poster_path;
            Genres = genres;
            Overview = overview;
            ReleaseDate = release_date;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; }
        public string Name { get; }

        public GenresViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
