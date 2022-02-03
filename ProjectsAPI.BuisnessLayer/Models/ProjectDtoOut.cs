using ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAPI.Logic.Models
{
    public class ProjectDtoOut
    {
        public string? ProjectName { get; set; }
        public Employee? ProjectManager { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string? Contracter { get; set; }
        public string? Client { get; set; }
        public List<Assignment>? Assignments;
    }
}
