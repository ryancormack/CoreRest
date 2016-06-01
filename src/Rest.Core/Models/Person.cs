using Rest.Core.Enums;
using System;
using System.Collections.Generic;

namespace Rest.Core.Models
{
    public class Person
    {
        public Person(string name, IEnumerable<Skills> skills)
        {
            Name = name;
            Skills = skills;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        public IEnumerable<Skills> Skills { get; }
    }
}
