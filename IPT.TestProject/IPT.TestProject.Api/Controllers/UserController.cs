
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IPT.TestProject.Api.Controllers.Base;
using IPT.TestProject.Application.Services.Users.Commands.Add;
using IPT.TestProject.Application.Services.Users.Commands.Delete;
using IPT.TestProject.Application.Services.Users.Commands.Login;
using IPT.TestProject.Application.Services.Users.Commands.Update;
using IPT.TestProject.Application.Services.Users.Queries.Get;
using IPT.TestProject.Application.Services.Users.Queries.GetPermissions;

namespace IPT.TestProject.Api.Controllers
{
    [Route("api/users")]

    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetUserQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(":login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet(":get-user-permissions")]
        public async Task<IActionResult> GetUserPermissions([FromQuery] GetUserPermissionsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
