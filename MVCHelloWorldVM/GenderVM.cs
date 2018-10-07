using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHelloWorldVM
{
   public class GenderVM
    {
        public GenderVM()
        {
            this.Employees = new List<EmployeeVM>();
        }

        public int ID { get; set; }
        public string GenderDesc { get; set; }
        public virtual ICollection<EmployeeVM> Employees { get; set; }
    }
}
