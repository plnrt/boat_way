using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.VacancyManager
{
    public interface IVacancyManager
    {
        Task Create(Vacancy vacancy);

        Task Update(string Id, Vacancy vacancy);

        Task Delete(string Id);

        List<Vacancy> GetAll();

        Task DeleteAll();

        Task<Vacancy> Get(string Id);
    }
}
