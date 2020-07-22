using System;
using IPT.TestProject.Domain.Entities.Base;

namespace IPT.TestProject.Domain.Entities
{
    public class Movie : Entity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Category_Id { get; set; }

        public Category Category { get; set; }

        public double  Rate { get; set; }
    }
}
