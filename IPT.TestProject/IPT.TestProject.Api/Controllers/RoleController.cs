﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IPT.TestProject.Api.Controllers.Base;
using IPT.TestProject.Application.Services.Roles.Commands.Create;
using IPT.TestProject.Application.Services.Roles.Queries.Get;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Authorization;

namespace IPT.TestProject.Api.Controllers
{
    [Route("api/roles")]

    public class RoleController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] GetRoleQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
