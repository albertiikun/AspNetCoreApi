using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IPT.TestProject.Api.Controllers.Base;
using IPT.TestProject.Application.Services.Categories.Commands.Add;
using IPT.TestProject.Application.Services.Categories.Commands.Delete;
using IPT.TestProject.Application.Services.Categories.Commands.Update;
using IPT.TestProject.Application.Services.Categories.Queries.Get;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace IPT.TestProject.Api.Controllers
{
    [Route("api/movies/categories")]
    public class MovieCategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteCategory([FromBody] UpdateCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
