using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserManager
{
    public interface IUserManager
    {
        Task Create(User user);

        Task Update(string Id, User user);

        Task Delete(string Id);

        Task<User> Get(string Id);

        User Login(string Login, string Password);
    }
}
