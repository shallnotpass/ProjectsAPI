using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Domain.Entities
{
    public class Assignment : IDomainEntity
    {
        public int Id {get; set;}

        public int EmployeeId {get; set;}
        public Employee? Employee {get; set;}

        public int ProjectId {get; set; }
        public Project? Project {get; set;}
    }
}
