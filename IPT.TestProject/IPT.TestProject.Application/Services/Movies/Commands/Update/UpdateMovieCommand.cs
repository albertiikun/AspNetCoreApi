using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Movies.Commands.Update
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
