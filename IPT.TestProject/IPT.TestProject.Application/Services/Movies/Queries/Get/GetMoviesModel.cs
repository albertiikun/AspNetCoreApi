using System;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Movies.Queries.Get
{
    public class GetMoviesModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid Category_id { get; set; }
        public CategoryModel CategoryModel { get; set; }
    }
}