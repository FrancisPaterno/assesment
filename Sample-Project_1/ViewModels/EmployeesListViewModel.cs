using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample_Project_1.Models;

namespace Sample_Project_1.ViewModels
{
    public class EmployeesListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeeStatus> EmployeeStatuses { get; set; }
        public IEnumerable<String> Positions { get; set; }
    }
}