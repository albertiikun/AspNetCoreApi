using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id {get; set;}
    }
}
