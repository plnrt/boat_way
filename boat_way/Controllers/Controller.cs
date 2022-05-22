using Business.ResumeManager;
using Business.UserManager;
using Business.VacancyManager;
using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boat_way.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> _logger;

        private readonly IResumeManager resumeManager;

        private readonly IVacancyManager vacancyManager;

        private readonly IUserManager userManager;

        public Controller(ILogger<Controller> logger, IResumeManager resumeManager, IVacancyManager vacancyManager, IUserManager userManager)
        {
            this._logger = logger;
            this.resumeManager = resumeManager;
            this.vacancyManager = vacancyManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("getallresumes")]
        public IEnumerable<Resume> GetResumes()
        {
            return this.resumeManager.GetAll();
        }

        [HttpGet]
        [Route("getresume")]
        public async Task<Resume> GetResume(string Id)
        {
            return await this.resumeManager.Get(Id).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("deleteresume")]
        public async Task DeleteResume(string Id)
        {
            await this.resumeManager.Delete(Id).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("deleteallresumes")]
        public async Task DeleteAllResumes()
        {
            await this.resumeManager.DeleteAll().ConfigureAwait(false);
        }

        [HttpPost]
        [Route("createresume")]
        public async Task CreateResume(Resume resume)
        {
            await this.resumeManager.Create(resume);
        }

        [HttpPost]
        [Route("updateresume")]
        public async Task UpdateResume(string Id, Resume resume)
        {
            await this.resumeManager.Update(Id, resume);
        }

        [HttpGet]
        [Route("getallvacancies")]
        public IEnumerable<Vacancy> GetVacancys()
        {
            return vacancyManager.GetAll();
        }

        [HttpGet]
        [Route("getvacancy")]
        public async Task<Vacancy> GetVacancy(string Id)
        {
            return await this.vacancyManager.Get(Id).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("deletevacancy")]
        public async Task DeleteVacancy(string Id)
        {
            await this.vacancyManager.Delete(Id).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("deleteallvacancies")]
        public async Task DeleteAllVacancy()
        {
            await this.vacancyManager.DeleteAll().ConfigureAwait(false);
        }

        [HttpPost]
        [Route("createvacancy")]
        public async Task CreateVacancy(Vacancy resume)
        {
            await this.vacancyManager.Create(resume);
        }

        [HttpPost]
        [Route("updatevacancy")]
        public async Task UpdateVacancy(string Id, Vacancy resume)
        {
            await this.vacancyManager.Update(Id, resume);
        }

        [HttpGet]
        [Route("getuser")]
        public async Task<User> GetUser(string Id)
        {
            return await this.userManager.Get(Id).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("deleteuser")]
        public async Task DeleteUser(string Id)
        {
            await this.userManager.Delete(Id).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("createuser")]
        public async Task CreateUser(User user)
        {
            await this.userManager.Create(user);
        }

        [HttpPost]
        [Route("updateuser")]
        public async Task UpdateUser(string Id, User user)
        {
            await this.userManager.Update(Id, user);
        }

    }
}
