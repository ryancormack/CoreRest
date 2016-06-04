using Rest.Core.DatabaseModels;
using Rest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Database
{
    public class FakeDataStore : IDataStore
    {
        public IReadOnlyList<Profile> GetAllProfiles()
        {
            return Profiles;
        }

        public Profile GetProfileById(Guid userId)
        {
            return Profiles.Where(p => p.Id == userId).FirstOrDefault();
        }

        public static IReadOnlyList<Profile> Profiles = new List<Profile> {
            new Profile(Guid.Parse("4436BAE6-E7A1-4C4E-A77A-535CBDDA5793"), "Ryan", new List<Skills> { Skills.DotNet}) { Nationality = new Rest.Core.Models.Nationality { Country = "United Kingdom" }, User = new User { Email = "ryan@helloworld.com", UserId = Guid.Parse("EAD8648F-3DBA-44A6-8DF5-B5F0433053F8") } },

            new Profile(Guid.Parse("1ED7F177-8B5F-4303-A74B-D81723E951F0"), "John", new List<Skills> { Skills.Java}) { Nationality = new Rest.Core.Models.Nationality { Country = "Sweden" }, User = new User { Email = "john@helloworld.com", UserId = Guid.Parse("A0CD1AB3-2AC4-4EC6-A173-2C85B24302DC") } },

            new Profile(Guid.Parse("C00C5168-AC02-47C9-AE6E-9A6E66AAE98B"), "Jane", new List<Skills> { Skills.DotNet, Skills.Java}) { Nationality = new Rest.Core.Models.Nationality { Country = "France" }, User = new User { Email = "jane@helloworld.com", UserId = Guid.Parse("4CF97BC5-0CCB-420F-9F7C-68225DE81210") } }

        };
    }

    public interface IDataStore {
        IReadOnlyList<Profile> GetAllProfiles();
        Profile GetProfileById(Guid userId);
    }
}
