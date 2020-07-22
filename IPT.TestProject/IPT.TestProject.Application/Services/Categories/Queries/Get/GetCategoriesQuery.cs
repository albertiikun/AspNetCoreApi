using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPT.TestProject.Application.Services.Categories.Queries.Get
{
    public class GetCategoriesQuery : IRequest<IList<GetCategoriesModel>>
    {
    }
}
