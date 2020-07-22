using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Movies.Queries.Get
{
    public class GetMoviesQuery : IRequest<IList<GetMoviesModel>>
    {
    }
}
