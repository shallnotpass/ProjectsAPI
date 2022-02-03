
using ProjectAPI.DataAccess;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Logic.Contracts;
using ProjectsAPI.Logic.Models;

namespace ProjectAPI.Logic
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationContext dbContext;

        public ProjectService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Add(ProjectDtoIn project)
        {
            var projectDbo = new Project()
            {
                ProjectName = project.ProjectName,
                Client = project.Client,
                Contracter = project.Contracter,
                FinishDate = project.FinishDate,
                Priority = project.Priority,
                StartDate = project.StartDate,
                ProjectManager = dbContext.Employees.Find(project.ProjectManagerId),
                Assignments = new List<Assignment>()
            };
            dbContext.Projects.Add(projectDbo);
            dbContext.SaveChanges();
            return 1;
        }
        public async Task<int> AssignEmployee(int projectId, int employeeId)
        {
            var project = dbContext.Projects.Find(projectId);
            if (project != null)
            {
                var employee = dbContext.Employees.Find(employeeId);

                if (employee != null )
                {
                    var assgnment = new Assignment
                    {
                        EmployeeId = employeeId,
                        ProjectId = projectId
                    };
                    dbContext.Assignments.Add(assgnment);
                    dbContext.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }

        public async Task<int> Delete(int id)
        {
            var user = dbContext.Projects.Find(id);
            if (user != null)
            { 
                dbContext.Remove(user);
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<ProjectDtoOut> GetInfoById(int projectId)
        {
            var project = dbContext.Projects.Find(projectId);
            if (project != null)
            { 
                var projectDbo = new ProjectDtoOut()
                {
                    ProjectName = project.ProjectName,
                    Client = project.Client,
                    Contracter = project.Contracter,
                    FinishDate = project.FinishDate,
                    Priority = project.Priority,
                    StartDate = project.StartDate,
                    ProjectManager = project.ProjectManager,
                    Assignments = project.Assignments
                };
                return projectDbo;
            }
            return null;
        }

        public async Task<int> DeassignEmployee(int projectId, int employeeId)
        {
        var project = dbContext.Projects.Find(projectId);
        if (project != null)
        {
            var employee = dbContext.Employees.Find(employeeId);
            if (employee != null)
            {
               if (dbContext.Assignments.Count() != 0)
               {
                   var assignmentId = project.Assignments.FirstOrDefault(x => x.EmployeeId == employee.Id).Id;
                   var entry = dbContext.Assignments.FirstOrDefault(x => x.Id == assignmentId);
                   dbContext.Assignments.Remove(entry);
                   dbContext.Update(project);
                   dbContext.Update(employee);
                   dbContext.SaveChanges();
                   return 1;
               }
            }
        }
        return 0;
        }

        public async Task<int> Update(ProjectDtoIn project, int projectId)
        {
            var projectDbo = dbContext.Projects.Find(projectId);
            if (projectDbo != null)
            {
                projectDbo.ProjectName = project.ProjectName;
                projectDbo.Client = project.Client;
                projectDbo.Contracter = project.Contracter;
                projectDbo.FinishDate = project.FinishDate;
                projectDbo.Priority = project.Priority;
                projectDbo.StartDate = project.StartDate;
                projectDbo.ProjectManager = dbContext.Employees.Find(project.ProjectManagerId);
                dbContext.Update(projectDbo);
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }


        
        public async Task <IEnumerable<ProjectDtoOut>> FindBy(int? sortingType, string? projectName, int? maxPriority, int? minPriority)
        {
            IEnumerable<Project> projects;
            switch (sortingType)
            {
                default:
                    projects = dbContext.Projects;
                    break;
                case 0:
                    projects = dbContext.Projects.OrderBy(x => x.Priority);
                    break;
                case 1:
                    projects = dbContext.Projects.OrderBy(x => x.StartDate);
                    break;
                case 2:
                    projects = dbContext.Projects.OrderBy(x => x.FinishDate);
                    break;
            }
            if (!string.IsNullOrEmpty(projectName))
                projects = projects.Where(x => x.ProjectName.Contains(projectName));
            if (maxPriority != null)
                projects = projects.Where(x => x.Priority < maxPriority);
            if (minPriority != null)
                projects = projects.Where(x => x.Priority > minPriority);
            return projects
            .Select(project => new ProjectDtoOut()
            {
                ProjectName = project.ProjectName,
                Client = project.Client,
                Contracter = project.Contracter,
                FinishDate = project.FinishDate,
                Priority = project.Priority,
                StartDate = project.StartDate,
                ProjectManager = project.ProjectManager,
                Assignments = project.Assignments
            })
            .ToList();
        }  
    }
}