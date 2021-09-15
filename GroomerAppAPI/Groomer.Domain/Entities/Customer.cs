using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Domain.Entities
{
   public class Customer 
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public ICollection<Pet> Pets { get; set; }       

    }
}
