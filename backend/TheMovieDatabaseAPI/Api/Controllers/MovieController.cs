using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;

namespace TheMovieDatabaseAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("upcoming/{page:int}")]
        [HttpGet]
        public async Task<IActionResult> GetUpcoming(int page)
        {
            var query = new GetUpcomingMoviesQuery(page);
            var upcomingMovies = await _mediator.Send(query);
            return Ok(upcomingMovies);
        }

        [Route("details/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id)
        {
            var query = new GetMovieDetailsQuery(id);
            var movieDetails = await _mediator.Send(query);
            return Ok(movieDetails);
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Search(string title)
        {
            var query = new SearchMoviesQuery(title);
            var searchedMovies = await _mediator.Send(query);
            return Ok(searchedMovies);
        }
    }
}