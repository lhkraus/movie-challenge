using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheMovieDatabaseAPI.Application.Queries;

namespace TheMovieDatabaseAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("movie/list")]
        [HttpGet]
        public async Task<IActionResult> ListMoviesGenres()
        {
            var query = new GetMoviesGenresQuery();
            var moviesGenres = await _mediator.Send(query);
            return Ok(moviesGenres);
        }
    }
}
