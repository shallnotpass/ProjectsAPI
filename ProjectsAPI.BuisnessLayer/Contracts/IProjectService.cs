using ProjectAPI.Domain;
using ProjectsAPI.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Logic.Contracts
{
    public interface IProjectService
    {
        Task<int> Add(ProjectDtoIn project);
        Task<int> Update(ProjectDtoIn project, int projectId);
        Task<int> Delete(int id);
        Task<int> AssignEmployee(int projectId, int employeeId);
        Task<int> DeassignEmployee(int projectId, int employeeId);
        Task<ProjectDtoOut> GetInfoById(int employeeId);
        Task<IEnumerable<ProjectDtoOut>> FindBy(int? sortingType, string? projectName, int? maxPriority, int? minPriority);
    }
}
