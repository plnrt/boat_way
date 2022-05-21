using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ResumeManager
{
    public interface IResumeManager
    {
        Task Create(Resume resume);

        Task Update(string Id,Resume resume);

        Task Delete(string Id);

        List<Resume> GetAll();

        Task DeleteAll();
        
        Task<Resume> Get();
    }
}
