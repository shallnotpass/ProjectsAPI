
using ProjectAPI.DataAccess;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Logic.Contracts;
using ProjectsAPI.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Logic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationContext dbContext;

        public EmployeeService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> Add(EmployeeDTO employee)
        {
            var employeeDB = new Employee()
            {
                Name = employee.Name,
                SecondName = employee.SecondName,
                Patronymic = employee.Patronymic,
                email = employee.email,
                Assignments = new List<Assignment>()
            };
            dbContext.Employees.Add(employeeDB);
            dbContext.SaveChanges();
            return 1;
        }
        public async Task<int> Delete(int bookId)
        {
            var book = dbContext.Employees.Find(bookId);
            if (book != null)
            {
                dbContext.Employees.Remove(book);
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<int> Update(EmployeeDTO employee, int employeeId)
        {
            var employeeDbo = dbContext.Employees.Find(employeeId);
            if (employee == null) return 0;
            employeeDbo.Name = employee.Name;
            employeeDbo.SecondName = employee.SecondName;
            employeeDbo.Patronymic = employee.Patronymic;
            employeeDbo.email = employee.email;
            employeeDbo.Assignments = employee.Assignments;
            dbContext.Update(employeeDbo);
            dbContext.SaveChanges();
            return 1;
        }
        public async Task<EmployeeDTO> GetInfoById(int employeeId)
        {
            var employee = dbContext.Employees.Find(employeeId);
            if (employee == null) return null;
            var employeeDTO = new EmployeeDTO()
            {
                Name = employee.Name,
                SecondName = employee.SecondName,
                Patronymic = employee.Patronymic,
                email = employee.email,
                Assignments = employee.Assignments
            };
            return employeeDTO;
        }
    }
}
