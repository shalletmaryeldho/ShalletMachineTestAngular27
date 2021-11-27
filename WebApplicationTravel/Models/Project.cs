using System;
using System.Collections.Generic;

namespace WebApplicationTravel.Models
{
    public partial class Project
    {
        public Project()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public decimal ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
