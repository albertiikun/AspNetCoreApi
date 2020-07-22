using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IPT.TestProject.Api.Controllers.Base;
using IPT.TestProject.Application.Services.Movies.Commands.Add;
using IPT.TestProject.Application.Services.Movies.Commands.Delete;
using IPT.TestProject.Application.Services.Movies.Commands.Update;
using IPT.TestProject.Application.Services.Movies.Queries.Get;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace IPT.TestProject.Api.Controllers
{
    [Route("api/movies")]
    public class MovieController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] GetMoviesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteMovie([FromBody] UpdateMovieCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromBody] DeleteMovieCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
