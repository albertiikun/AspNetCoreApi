using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Movies.Commands.Delete
{
    public class DeleteMovieCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
