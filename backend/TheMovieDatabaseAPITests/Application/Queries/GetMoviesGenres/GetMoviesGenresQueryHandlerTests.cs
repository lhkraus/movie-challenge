using FluentAssertions;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;
using TheMovieDatabaseAPI.Client;
using Xunit;

namespace TheMovieDatabaseAPITests.Application.Queries.GetMoviesGenres
{
    public class GetMoviesGenresQueryHandlerTests
    {
        private readonly Mock<ITMDbClient> _clientMock;
        private readonly GetMoviesGenresQueryHandler _handler;

        public GetMoviesGenresQueryHandlerTests()
        {
            _clientMock = new Mock<ITMDbClient>();
            _handler = new GetMoviesGenresQueryHandler(_clientMock.Object);
        }

        [Fact]
        public async void Handle_ShouldFetchAllMoviesGenres()
        {
            var json = File.ReadAllText("./TestAssets/getMoviesGenresResponse.json");

            _clientMock
                .Setup(client => client.GetMoviesGenres())
                .Returns(Task.FromResult(JObject.Parse(json)));

            var query = new GetMoviesGenresQuery();
            var moviesGenres = await _handler.Handle(query, default);

            moviesGenres
                .Should()
                .NotBeEmpty();
        }
    }
}
