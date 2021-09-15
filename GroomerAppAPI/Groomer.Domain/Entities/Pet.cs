using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Domain.Entities
{
   public class Pet
    {
        public int PetId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int age { get; set; }
        public string ownerId { get; set; }
        public Customer owner { get; set; }
    }
}
