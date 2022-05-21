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
        private IDataBaseManager<Resume> Repository;
        public ResumeManager(IDataBaseManager<Resume> repository)
        {
            Repository = repository;
        }

        public async Task Create(Resume resume)
        {
            resume.Id = Guid.NewGuid().ToString();
            resume.Created = DateTime.Now;
            await this.Repository.Add(resume).ConfigureAwait(false);
        }

        public async Task Delete(string id)
        {
            await this.Repository.Delete(id).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public async Task DeleteAll()
        {
            await this.Repository.Clear().ConfigureAwait(false);
        }

        public async Task<Resume> Get(string Id)
        {
            return await this.Repository.Get(Id).ConfigureAwait(false);
        }

        public Task<Resume> Get()
        {
            throw new NotImplementedException();
        }

        public List<Resume> GetAll()
        {
            return this.Repository.GetAll();
        }

        public async Task Update(string Id,Resume resume)
        {
            await this.Repository.Modify(Id , resume).ConfigureAwait(false);
        }
    }
}
