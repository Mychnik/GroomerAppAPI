using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Groomer.Core.Functions.Employees.Queries.GetEmployeeDetailsQuery
{
   public class EmployeeDetailModel
    {
        public string name { get; set; }
        public string surename { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int  yearsOfExp { get; set; }
        //public IFormFile Image { get; set; }
    }
}
