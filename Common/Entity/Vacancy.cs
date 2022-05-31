using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Vacancy : BaseEntity
    {
        public string UserId { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
    }
}
