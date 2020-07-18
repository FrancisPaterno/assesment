using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample_Project_1.Models;
using Sample_Project_1.ViewModels;

namespace Sample_Project_1.Controllers
{
    public class EmployeeController : Controller
    {
        private SampleProjectContext _context;

        public EmployeeController() {
            _context = new SampleProjectContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //New Employee
        public ActionResult New() {
            var employeeStatuses = _context.EmployeeStatus.ToList();
            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                EmployeeStatuses = employeeStatuses
            };
            return View("EmployeeForm", viewModel);
        }

        // GET: Employee
        public ActionResult Index()
        {
            var positions = _context.Employees.Select(p => p.Position).Distinct().ToList();
            var status = _context.EmployeeStatus;

            var employeeListViewModel = new EmployeesListViewModel
            {
                EmployeeStatuses = status,
                Positions = positions
            };
            return View("Index", employeeListViewModel);
            //return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Employee_Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                EmployeeStatuses = _context.EmployeeStatus.ToList()
            };

            return View("EmployeeForm", viewModel);
        }

        //Save
        [HttpPost]
        public ActionResult Save(Employee employee) {
            if (!ModelState.IsValid) {
                var viewModel = new EmployeeFormViewModel {
                    Employee = employee,
                    EmployeeStatuses = _context.EmployeeStatus.ToList()
                };
                return View("EmployeeForm", viewModel);
            }

            if (employee.Employee_Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else {
                var employeeInDb = _context.Employees.Single(c => c.Employee_Id == employee.Employee_Id);
                employeeInDb.Firstname = employee.Firstname;
                employeeInDb.MiddleInitial = employee.MiddleInitial;
                employeeInDb.Lastname = employee.Lastname;
                employeeInDb.BasicSalary = employee.BasicSalary;
                employeeInDb.Position = employee.Position;
                employeeInDb.SSS = employee.SSS;
                employeeInDb.PhilHealth = employee.PhilHealth;
                employeeInDb.EmployeeStatusStatus_id = employee.EmployeeStatusStatus_id;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
