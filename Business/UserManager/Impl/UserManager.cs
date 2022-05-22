using Common.Entity;
using Persistance.Contexts;
using Persistance.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserManager.Impl
{
    public class UserManager : IUserManager
    {
        private IDataBaseManager<User> DataBaseManage;
        public UserManager(IDataBaseManager<User> repository)
        {
            DataBaseManage = repository;
        }
        public async Task Create(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.Created = DateTime.Now;
            await DataBaseManage.Add(new DatabaseContext(), user).ConfigureAwait(false);
        }
        public async Task Delete(string id)
        {
            await this.DataBaseManage.Delete(new DatabaseContext(), id).ConfigureAwait(false);
        }

        public async Task<User> Get(string Id)
        {
            return await this.DataBaseManage.Get(new DatabaseContext(), Id).ConfigureAwait(false);
        }

        public async Task Update(string Id, User user)
        {
            await this.DataBaseManage.Modify(new DatabaseContext(), Id, user).ConfigureAwait(false);
        }
    }
}
