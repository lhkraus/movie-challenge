namespace TheMovieDatabaseAPI.Application.Queries
{
    public class MoviesGenreViewModel
    {
        public int Id { get; }
        public string Name { get; }

        public MoviesGenreViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
