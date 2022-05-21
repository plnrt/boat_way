using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class User : BaseEntity
    {
        public string Surname { get; set; }
        public UserType UserType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<Resume> Resumes { get; set; }
        public virtual List<Vacancy> Vacancies { get; set; }
    }
}
