using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.Models;
using EmployeeManager.Data;

namespace EmployeeManager.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public bool AddEmployee(string name, string role, string status, string parkingLot)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(role))
                return false;

            var emp = new Employee
            {
                Name = name,
                Role = role,
                Status = status,
                ParkingLotName = parkingLot
            };

            _context.Employees.Add(emp);
            _context.SaveChanges();
            return true;
        }
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}

