using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTravel.Models;

namespace WebApplicationTravel.Repository
{
    public interface IEmployee
    {
        Task<List<Registration>> GetEmployees();
        Task<Registration> AddEmployees(Registration request);
        Task<Registration> UpdateEmployees(Registration request);
    }
}
