using System;
using System.Collections.Generic;

namespace WebApplicationTravel.Models
{
    public partial class Login
    {
        public Login()
        {
            Registration = new HashSet<Registration>();
        }

        public decimal LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
