using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Models
{
    public class RegisterAccountViewModel
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
