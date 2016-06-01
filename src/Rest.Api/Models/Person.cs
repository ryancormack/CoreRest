using System;

namespace Restival.Models
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
    }
}
