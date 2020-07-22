using System;
using System.Collections;
using System.Collections.Generic;
using IPT.TestProject.Domain.Entities.Base;

namespace IPT.TestProject.Domain.Entities
{

    public class Category : Entity
    {
        public Category()
        {
            Movies = new HashSet<Movie>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
