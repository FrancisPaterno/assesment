using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample_Project_1.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "M.I.")]
        public string MiddleInitial { get; set; }
        [Range(10000, 1000000)]
        [Display(Name ="Basic Salary")]
        public double BasicSalary { get; set; }
        [Required]
        public string Position { get; set; }
        public string SSS { get; set; }
        public string PhilHealth { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }
        [Required]
        public int EmployeeStatusStatus_id { get; set; }
    }
}