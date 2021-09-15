using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Application.Models
{
   public class ChangePasswordViewModel
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
    }
}
