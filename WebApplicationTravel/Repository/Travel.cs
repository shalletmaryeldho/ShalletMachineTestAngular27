using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTravel.Models;
using WebApplicationTravel.ViewModel;

namespace WebApplicationTravel.Repository
{
    public class Travel : ITravel
    {
        private DBTravelContext db;
        public Travel(DBTravelContext _db)
        {
            db = _db;
        }
        #region GetRequests

      
        public async Task<List<RequestTable>> GetRequests()
        {
            if (db != null)
            {
                return await db.RequestTable.ToListAsync();
            }
            return null;

        }
        #endregion

        #region AddRequests

        //add patients
        public async Task<RequestTable> AddRequests(RequestTable request)
        {
            if (db != null)
            {
                await db.RequestTable.AddAsync(request);
                await db.SaveChangesAsync(); //commit the transaction

                return request;
            }
            return null;
        }

        #endregion


        #region 

        public async Task<RequestTable> UpdateRequests(RequestTable request)
        {
            if (db != null)
            {
                db.RequestTable.Update(request);
                await db.SaveChangesAsync();
                return request;
            }
            return null;
        }

        #endregion

        #region GetAllRequests
        //viewmodel
        public async Task<List<EmpViewModel>> GetAllRequests()
        {
            if (db != null)
            {
                //linq
            
                return await (from p in db.RequestTable
                              from c in db.Registration
                              where p.EmpId == c.EmpId
                              select new EmpViewModel
                              {
                                  EmpId = c.EmpId ,
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,

                                  Priority = p.Priority
                              }
                             ).ToListAsync();
            }
            return null;
        }

        #endregion



    }
}
