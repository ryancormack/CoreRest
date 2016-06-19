using Rest.Core.DatabaseModels;
using System;
using System.Collections.Generic;
using Rest.Core.Enums;

namespace Rest.ApiModels
{
    public class UserApiModel
    {
        public UserApiModel(User user) {
            UserId = user.UserId;
            Email = user.Email;
            Name = user.Profile.Name;
            Nationality = user.Profile.Nationality.Country;
            Skills = MakeSkillsFriendly(user.Profile.Skills);
        }

        public UserApiModel() { }

        public Guid UserId { get; }
        public string Email { get; }
        public string Name { get; }
        public string Nationality { get; }
        public IReadOnlyList<string> Skills { get; }

        private IReadOnlyList<string> MakeSkillsFriendly(IEnumerable<Skills> skills) {
            List<string> friendlySkills = new List<string>();
            foreach (var skill in skills) {
                friendlySkills.Add(skill.ToString());
            }
            return friendlySkills;
        }
    }
}
