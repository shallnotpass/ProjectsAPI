using System.Collections.Generic;

namespace ProjectAPI.Domain.Entities
{
    public class Employee : IDomainEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SecondName { get; set; }
        public string? Patronymic { get; set; }
        public string? email { get; set; }

        public List<Assignment> Assignments = new();
    }
}