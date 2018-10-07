using System;
using System.Collections.Generic;

namespace MVCHelloWorldEntity.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
