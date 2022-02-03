using ProjectAPI.Logic.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsAPI.Logic.Models;

namespace ProjectsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpPost("Add")]
        public async Task<int> Add(EmployeeDTO employee)
        {
            return await employeeService.Add(employee);
        }

        [HttpPut("Update")]
        public async Task<int> Update(EmployeeDTO book, int employeeId)
        {
            return await employeeService.Update(book, employeeId);
        }

        [HttpDelete("Delete")]
        public async Task<int> Delete(int bookId)
        {
            return await employeeService.Delete(bookId);
        }
        [HttpGet("GetInfo")]
        public async Task<EmployeeDTO> GetInfoById(int employeeId)
        {
            return await employeeService.GetInfoById(employeeId);
        }
    }
}
