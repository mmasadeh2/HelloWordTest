using System;
using System.Collections.Generic;

namespace MVCHelloWorldEntity.Models
{
    public partial class Gender
    {
        public Gender()
        {
            this.Employees = new List<Employee>();
        }

        public int ID { get; set; }
        public string GenderDesc { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
