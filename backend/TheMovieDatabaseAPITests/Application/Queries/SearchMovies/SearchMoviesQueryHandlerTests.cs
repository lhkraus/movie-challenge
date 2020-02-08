using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;
using TheMovieDatabaseAPI.Client;
using Xunit;

namespace TheMovieDatabaseAPITests.Application.Queries.SearchMovies
{
    public class SearchMoviesQueryHandlerTests
    {
        private readonly Mock<ITMDbClient> _clientMock;
        private readonly SearchMoviesQueryHandler _handler;

        public SearchMoviesQueryHandlerTests()
        {
            _clientMock = new Mock<ITMDbClient>();
            _handler = new SearchMoviesQueryHandler(_clientMock.Object);
        }

        [Fact]
        public async void Handle_ShouldFindTheMoviesByTitle()
        {
            var json = File.ReadAllText("./TestAssets/searchMoviesResponse.json");

            _clientMock
                .Setup(client => client.SearchMovieAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(JObject.Parse(json)));

            var query = new SearchMoviesQuery(title: "fight");
            var searchedMovies = await _handler.Handle(query, default);

            searchedMovies
                .Should()
                .NotBeEmpty();

            searchedMovies
                .Should()
                .HaveCount(20);
        }
    }
}
