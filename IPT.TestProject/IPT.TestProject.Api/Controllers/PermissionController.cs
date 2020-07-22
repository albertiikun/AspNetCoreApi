using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IPT.TestProject.Api.Controllers.Base;
using IPT.TestProject.Application.Services.Permissions.Commands.Add;
using IPT.TestProject.Application.Services.Permissions.Commands.Assign;
using IPT.TestProject.Application.Services.Permissions.Queries.Get;

namespace IPT.TestProject.Api.Controllers
{
    [Route("api/permissions")]
    public class PermissionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPermissionsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPermissionCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(":assign")]
        public async Task<IActionResult> Assign([FromBody]AssignPermissionCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
