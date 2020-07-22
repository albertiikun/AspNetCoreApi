using System;
using System.Collections;
using System.Collections.Generic;
using IPT.TestProject.Application.Models;

namespace IPT.TestProject.Application.Services.Categories.Queries.Get
{
    public class GetCategoriesModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IList<MovieModel> Movies { get; set; } = new List<MovieModel>();
    }
}