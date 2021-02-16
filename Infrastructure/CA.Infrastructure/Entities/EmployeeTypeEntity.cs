using System;
using System.Collections.Generic;

namespace CA.Infrastructure.Entities
{
    public class EmployeeTypeEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
