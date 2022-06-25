using System;

namespace TemplatesNUnitsTests.Models
{
    internal class User : Entity<User>
    {
        public string Login { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }

    internal class Employee : Entity<Employee>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    internal abstract class Entity<T> where T : class
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}