using Rest.Core.DatabaseModels;
using Rest.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.DAL.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly IDataStore database;

        public UserRepository(IDataStore database)
        {
            this.database = database;
        }

        public IReadOnlyList<User> GetAllProfiles()
        {
            return database.Users();
        }

        public User GetUserById(Guid userId)
        {
            return database.Users().Where(u => u.UserId == userId).FirstOrDefault();
        }
    }

    public interface IUserRepository
    {
        IReadOnlyList<User> GetAllProfiles();
        User GetUserById(Guid userId);
    }
}
