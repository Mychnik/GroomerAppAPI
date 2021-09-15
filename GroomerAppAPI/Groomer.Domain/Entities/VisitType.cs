using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Domain.Entities
{
   public class VisitType
    {
        public int visitTypeId { get; set; }
        public string name { get; set; }
        public int requiredTime { get; set; }
        public int cost { get; set; }
        
    }
}
