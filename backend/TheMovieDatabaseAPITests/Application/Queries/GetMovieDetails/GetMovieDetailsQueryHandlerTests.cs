using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;
using TheMovieDatabaseAPI.Client;
using Xunit;

namespace TheMovieDatabaseAPITests.Application.Queries.GetMovieDetails
{
    public class GetMovieDetailsQueryHandlerTests
    {
        private readonly Mock<ITMDbClient> _clientMock;
        private readonly GetMovieDetailsQueryHandler _handler;

        public GetMovieDetailsQueryHandlerTests()
        {
            _clientMock = new Mock<ITMDbClient>();
            _handler = new GetMovieDetailsQueryHandler(_clientMock.Object);
        }

        [Fact]
        public async void Handle_ShouldFetchTheMovieDetails()
        {
            var json = File.ReadAllText("./TestAssets/getMovieDetailsResponse.json");

            _clientMock
                .Setup(client => client.GetMovieDetailsAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(JObject.Parse(json)));

            var query = new GetMovieDetailsQuery(id: 530915);
            var movieDetails = await _handler.Handle(query, default);

            movieDetails.Title.Should().Be("1917");
            movieDetails.Overview.Should().NotBeEmpty();
            movieDetails.Poster.Should().Be("/iZf0KyrE25z1sage4SYFLCCrMi9.jpg");
            movieDetails.ReleaseDate.Should().Be("2019-12-10");
            movieDetails.Genres.Should().HaveCount(3);
        }
    }
}
