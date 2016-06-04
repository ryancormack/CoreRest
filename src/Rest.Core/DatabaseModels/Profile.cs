using Rest.Core.Enums;
using Rest.Core.Models;
using System;
using System.Collections.Generic;

namespace Rest.Core.DatabaseModels
{
    public class Profile
    {
        public Profile(Guid profileId, string name, List<Skills> skills) {
            this.Id = profileId;
            this.Name = name;
            this.Skills = skills;
            this.FriendlySkills = MakeSkillsFriendly(skills);
        }

        public Profile() { }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Skills> Skills { get; set; }
        public Nationality Nationality { get; set; }
        public User User { get; set; }
        public IReadOnlyList<string> FriendlySkills { get; set; }

        private List<string> MakeSkillsFriendly(List<Skills> skills) {
            List<string> friendlySkills = new List<string>();

            foreach (var skill in skills) {
                friendlySkills.Add(skill.ToString());
            }

            return friendlySkills;
        }
    }
}
