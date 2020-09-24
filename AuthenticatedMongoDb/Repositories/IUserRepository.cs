using AuthenticatedMongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public void UpdateFirstName(Guid Id, string FirstName);
        public User GetByUsername(string Username);
    }
}
