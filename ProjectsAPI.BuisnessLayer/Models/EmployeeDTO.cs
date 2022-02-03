using ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAPI.Logic.Models
{
    public class EmployeeDTO
    {
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Patronymic { get; set; }
        public string? email { get; set; }

        public List<Assignment>? Assignments;
    }
}
