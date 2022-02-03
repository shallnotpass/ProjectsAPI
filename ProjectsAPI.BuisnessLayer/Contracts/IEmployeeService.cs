using ProjectAPI.Domain;
using ProjectsAPI.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Logic.Contracts
{
    public interface IEmployeeService
    {
        Task<int> Add(EmployeeDTO employee);
        Task<int> Update(EmployeeDTO employee, int employeeId);
        Task<int> Delete(int employeeId);
        Task<EmployeeDTO> GetInfoById(int employeeId);
        //Task<IEnumerable<IBookDto>> GetBooklistByUserId(int userId);
        //Task<IEnumerable<IBookDto>> GetAvalableBooks();
        //Task<IEnumerable<IBookDto>> FindBookByName(string name);
    }
}
