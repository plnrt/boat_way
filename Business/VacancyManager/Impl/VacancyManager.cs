using Common.Entity;
using Persistance.Contexts;
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
            await this.DataBaseManage.Add(new DatabaseContext(), vacancy).ConfigureAwait(false);
        }

        public async Task Delete(string id)
        {
            await this.DataBaseManage.Delete(new DatabaseContext(), id).ConfigureAwait(false);
        }

        public async Task DeleteAll()
        {
            await this.DataBaseManage.Clear(new DatabaseContext()).ConfigureAwait(false);
        }

        public async Task<Vacancy> Get(string Id)
        {
            return await this.DataBaseManage.Get(new DatabaseContext(), Id).ConfigureAwait(false);
        }

        public List<Vacancy> GetAll()
        {
            return this.DataBaseManage.GetAll(new DatabaseContext());
        }

        public async Task Update(string Id, Vacancy vacancy)
        {
            await this.DataBaseManage.Modify(new DatabaseContext(), Id, vacancy).ConfigureAwait(false);
        }
    }
}
