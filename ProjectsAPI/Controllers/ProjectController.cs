using ProjectAPI.Logic.Contracts;
using Microsoft.AspNetCore.Mvc;
using ProjectsAPI.Logic.Models;

namespace ProjectsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        [HttpPost("Add")]
        public async Task<int> Add(ProjectDtoIn book)
        {
            return await projectService.Add(book);
        }

        [HttpPut("Update")]
        public async Task<int> Update(ProjectDtoIn project, int projectId)
        {
            return await projectService.Update(project, projectId);
        }

        [HttpDelete("Delete")]
        public async Task<int> Delete(int projectId)
        {
            return await projectService.Delete(projectId);
        }

        [HttpPut("AssignEmployee")]
        public async Task<int> AssignEmployee(int projectId, int employeeId)
        {
            return await projectService.AssignEmployee(projectId, employeeId);
        }

        [HttpPut("DeassignEmployee")]
        public async Task<int> DeassignEmployee(int projectId, int employeeId)
        {
            return await projectService.DeassignEmployee(projectId, employeeId);
        }

        [HttpGet("GetInfo")]
        public async Task<ProjectDtoOut> GetInfoById(int projectId)
        {
            return await projectService.GetInfoById(projectId);
        }

        [HttpGet("Find")]
        public async Task<IEnumerable<ProjectDtoOut>> FindBy(int? sortingType, string? projectName, int? maxPriority, int? minPriority)
        {
            return await projectService.FindBy(sortingType, projectName, maxPriority, minPriority);
        }
    }
}
