using System;
using System.Collections.Generic;

namespace ProjectAPI.Domain.Entities
{
    public class Project : IDomainEntity
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; } = null!;
        public Employee? ProjectManager { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Contracter { get; set; } = null!;
        public string Client { get; set; } = null!;
        public List<Assignment> Assignments = new();
    }
}