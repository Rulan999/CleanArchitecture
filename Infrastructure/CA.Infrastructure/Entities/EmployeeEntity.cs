using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA.Infrastructure.Entities
{
    
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string TIN { get; set; }
        public int EmployeeType_Id { get; set; }

        [ForeignKey("EmployeeType_Id")]
        public EmployeeTypeEntity EmployeeType { get; set; }

    }
}
