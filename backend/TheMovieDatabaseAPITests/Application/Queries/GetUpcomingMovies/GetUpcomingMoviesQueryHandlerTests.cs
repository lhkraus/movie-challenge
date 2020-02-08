using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;
using TheMovieDatabaseAPI.Client;
using Xunit;

namespace TheMovieDatabaseAPITests.Application.Queries.GetUpcomingMovies
{
    public class GetUpcomingMoviesQueryHandlerTests
    {
        private readonly Mock<ITMDbClient> _clientMock;
        private readonly GetUpcomingMoviesQueryHandler _handler;

        public GetUpcomingMoviesQueryHandlerTests()
        {
            _clientMock = new Mock<ITMDbClient>();
            _handler = new GetUpcomingMoviesQueryHandler(_clientMock.Object);
        }

        [Fact]
        public async void Handle_ShouldReturnAListOfUpcomingMovies()
        {
            var json = File.ReadAllText("./TestAssets/getUpcomingMoviesResponse.json");

            _clientMock
                .Setup(client => client.GetUpcomingMoviesAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(JObject.Parse(json)));

            var query = new GetUpcomingMoviesQuery(page: 1);
            var upcomingMovies = await _handler.Handle(query, default);

            upcomingMovies
                .Should()
                .NotBeEmpty("Because 20 movies were fetched");

            upcomingMovies
                .Should()
                .HaveCount(20);
        }
    }
}
