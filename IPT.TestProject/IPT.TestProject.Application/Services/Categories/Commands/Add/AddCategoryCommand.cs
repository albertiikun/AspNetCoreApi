using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Categories.Commands.Add
{
    public class AddCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
