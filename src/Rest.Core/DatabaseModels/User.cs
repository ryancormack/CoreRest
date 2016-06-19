using System;

namespace Rest.Core.DatabaseModels
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
    }
}
