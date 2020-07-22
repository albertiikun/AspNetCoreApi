using System;

namespace IPT.TestProject.Domain.Entities.Base
{
    public class Entity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
