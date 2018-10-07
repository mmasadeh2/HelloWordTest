using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHelloWorldVM
{
   public class EmployeeVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="This Field Is Required")]
        [DisplayName ("The Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Please Enter A Valid Email Address")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public int GenderID { get; set; }
        public virtual GenderVM Gender { get; set; }
    }
}
