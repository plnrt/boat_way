using Common.Entity;
using Persistance.DataBaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.VacancyManager.Impl
{
    public class VacancyManager : IVacancyManager
    {
        private IDataBaseManager<Vacancy> DataBaseManage;
        public VacancyManager(IDataBaseManager<Vacancy> repository)
        {
            DataBaseManage = repository;
        }

        public async Task Create(Vacancy vacancy)
        {
            vacancy.Id = Guid.NewGuid().ToString();
            vacancy.Created = DateTime.Now;
            await this.DataBaseManage.Add(vacancy).ConfigureAwait(false);
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

        public async Task<Vacancy> Get(string Id)
        {
            return await this.DataBaseManage.Get(Id).ConfigureAwait(false);
        }

        public Task<Vacancy> Get()
        {
            throw new NotImplementedException();
        }

        public List<Vacancy> GetAll()
        {
            return this.DataBaseManage.GetAll();
        }

        public async Task Update(string Id, Vacancy vacancy)
        {
            await this.DataBaseManage.Modify(Id, vacancy).ConfigureAwait(false);
        }
    }
}
