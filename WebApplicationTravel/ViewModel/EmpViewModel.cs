using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTravel.ViewModel
{
    public class EmpViewModel
    {
      public decimal  EmpId { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }

      public decimal RequestId { get; set; }

      public string Priority { get; set; }
    }
}
