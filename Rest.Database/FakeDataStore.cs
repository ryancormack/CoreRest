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
        public IReadOnlyList<User> Users()
        {
            return new List<User> {
                new User {
                    UserId = Guid.Parse("EAD8648F-3DBA-44A6-8DF5-B5F0433053F8"),
                    Email = "ryan@helloworld.com",
                    Profile = new Profile {
                        Id = Guid.Parse("4436BAE6-E7A1-4C4E-A77A-535CBDDA5793"),
                        Name = "Ryan",
                        Skills = new List<Skills> { Skills.DotNet},
                        Nationality = new Nationality {Country = "United Kingdom" }
                    }
                },
                new User {
                    UserId = Guid.Parse("A0CD1AB3-2AC4-4EC6-A173-2C85B24302DC"),
                    Email = "john@helloworld.com",
                    Profile = new Profile {
                        Id = Guid.Parse("1ED7F177-8B5F-4303-A74B-D81723E951F0"),
                        Name = "John",
                        Skills = new List<Skills> {Skills.Java },
                        Nationality = new Nationality { Country = "Sweden"}
                    }
                },
                new User {
                    UserId = Guid.Parse("4CF97BC5-0CCB-420F-9F7C-68225DE81210"),
                    Email =  "jane@helloworld.com",
                    Profile = new Profile {
                        Id = Guid.Parse("C00C5168-AC02-47C9-AE6E-9A6E66AAE98B"),
                        Name = "Jane",
                        Skills = new List<Skills> {Skills.DotNet, Skills.Java },
                        Nationality = new Nationality {Country = "France" }
                    }
                }
            };
        }
    }

    public interface IDataStore
    {
        IReadOnlyList<User> Users();
    }
}
