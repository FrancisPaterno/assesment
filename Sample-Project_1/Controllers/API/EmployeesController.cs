using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using Sample_Project_1.Models;

namespace Sample_Project_1.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private SampleProjectContext _context;

        public EmployeesController()
        {
            _context = new SampleProjectContext();
        }

        // GET /api/employees
        public IHttpActionResult GetEmployees(int status, string position, string name ="")
        {
            var employeesQuery = _context.Employees.Include(e => e.EmployeeStatus);

            if (!String.IsNullOrWhiteSpace(name))
            {
                employeesQuery = employeesQuery.Where(c => c.Firstname.Contains(name)|| c.Lastname.Contains(name) || c.MiddleInitial.Contains(name));
            }

            if (!String.IsNullOrWhiteSpace(position)) {
                if(position != "All")
                employeesQuery = employeesQuery.Where(c => c.Position.Equals(position));
            }

            if (status != 0) {
                employeesQuery = employeesQuery.Where(c => c.EmployeeStatusStatus_id.Equals(status));
            }
            var empList = employeesQuery.ToList();
            return Ok(empList);
        }

        //Delete Employee
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id) {
            var employeeDb = _context.Employees.SingleOrDefault(e => e.Employee_Id == id);

            if (employeeDb == null)
                return NotFound();

            _context.Employees.Remove(employeeDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}