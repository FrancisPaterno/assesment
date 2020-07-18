using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample_Project_1.Models
{
    public class EmployeeStatus
    {
        [Key]
        public int Status_id { get; set; }
        public string Status { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}