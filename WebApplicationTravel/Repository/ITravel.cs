using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTravel.Models;
using WebApplicationTravel.ViewModel;

namespace WebApplicationTravel.Repository
{
    public interface ITravel
    {
        Task<List<RequestTable>> GetRequests();
        Task<RequestTable> AddRequests(RequestTable request);
        Task<RequestTable> UpdateRequests(RequestTable request);

        Task<List<EmpViewModel>> GetAllRequests();

    }
}
