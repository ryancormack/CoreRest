using Rest.Core.DatabaseModels;
using System;

namespace Rest.Core.DatabaseModels
{
    public class User
    {
        public User(Guid userId, string email) {
            this.UserId = userId;
            this.Email = email;
        }

        public User() { }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
    }
}
