using Common.Entity;
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
            await this.DataBaseManage.Add(resume).ConfigureAwait(false);
        }

        public async Task Delete(string id)
        {
            await this.DataBaseManage.Delete(id).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public async Task DeleteAll()
        {
            await this.DataBaseManage.Clear().ConfigureAwait(false);
        }

        public async Task<Resume> Get(string Id)
        {
            return await this.DataBaseManage.Get(Id).ConfigureAwait(false);
        }

        public Task<Resume> Get()
        {
            throw new NotImplementedException();
        }

        public List<Resume> GetAll()
        {
            return this.DataBaseManage.GetAll();
        }

        public async Task Update(string Id,Resume resume)
        {
            await this.DataBaseManage.Modify(Id , resume).ConfigureAwait(false);
        }
    }
}
