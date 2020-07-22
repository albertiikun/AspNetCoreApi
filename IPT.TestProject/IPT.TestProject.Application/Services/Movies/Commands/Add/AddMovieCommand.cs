using MediatR;
using System;

namespace IPT.TestProject.Application.Services.Movies.Commands.Add
{
    public class AddMovieCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
    }
}
