using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Domain.Entities
{
    public class Employee 
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public bool IsAvalible { get; set; }
        public ICollection<Visit> Visits { get; set; }
   
        
    }
}
