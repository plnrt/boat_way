using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Vacancy : BaseEntity
    {
        public string Position { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
    }
}
