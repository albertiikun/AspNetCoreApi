using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
