using Common.Entity;
using Persistance.Contexts;
using Persistance.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ResumeManager.Impl
{
    public class ResumeManager : IResumeManager
    {
        private IDataBaseManager<Resume> DataBaseManage;
        public ResumeManager(IDataBaseManager<Resume> repository)
        {
            DataBaseManage = repository;
        }

        public async Task Create(Resume resume)
        {
            resume.Id = Guid.NewGuid().ToString();
            resume.Created = DateTime.Now;
            await this.DataBaseManage.Add(new DatabaseContext(), resume).ConfigureAwait(false);
        }

        public async Task Delete(string id)
        {
            await this.DataBaseManage.Delete(new DatabaseContext(), id).ConfigureAwait(false);
        }

        public async Task DeleteAll()
        {
            await this.DataBaseManage.Clear(new DatabaseContext()).ConfigureAwait(false);
        }

        public async Task<Resume> Get(string Id)
        {
            return await this.DataBaseManage.Get(new DatabaseContext(), Id).ConfigureAwait(false);
        }

        public List<Resume> GetAll()
        {
            return this.DataBaseManage.GetAll(new DatabaseContext());
        }

        public async Task Update(string Id,Resume resume)
        {
            await this.DataBaseManage.Modify(new DatabaseContext(), Id , resume).ConfigureAwait(false);
        }
    }
}
