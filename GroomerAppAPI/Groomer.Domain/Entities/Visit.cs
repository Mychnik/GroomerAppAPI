using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomer.Domain.Entities
{
  public  class Visit
    {
        public int visitId { get; set; }
        //public int petId { get; set; }
        //public Pet pet { get; set; }
        public string customerId { get; set; }
        public Customer customer { get; set; }
        public string employeeId { get; set; }
        public Employee employee { get; set; }
        public DateTime visitStartDate { get; set; }
        public DateTime visitEndDate { get; set; }
        public int visitTypeId { get; set; }
        public VisitType visitType { get; set; }


    }
}
