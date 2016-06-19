using Rest.Core.Enums;
using System;
using System.Collections.Generic;

namespace Rest.Core.DatabaseModels
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Skills> Skills { get; set; }
        public Nationality Nationality { get; set; }
        
    }
}
