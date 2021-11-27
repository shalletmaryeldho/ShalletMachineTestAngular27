using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTravel.Models;

namespace WebApplicationTravel.Repository
{
    public class Employee : IEmployee
    {
        private DBTravelContext db;
        public Employee(DBTravelContext _db)
        {
            db = _db;
        }
        #region GetRequests

        //get all patients
        public async Task<List<Registration>> GetEmployees()
        {
            if (db != null)
            {
                return await db.Registration.ToListAsync();
            }
            return null;

        }
        #endregion

        #region AddRequests

        //add patients
        public async Task<Registration> AddEmployees(Registration employee)
        {
            if (db != null)
            {
                await db.Registration.AddAsync(employee);
                await db.SaveChangesAsync(); //commit the transaction

                return employee;
            }
            return null;
        }

        #endregion


        #region UpdatePatients
        //update patient record
        public async Task<Registration> UpdateEmployees(Registration employee)
        {
            if (db != null)
            {
                db.Registration.Update(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            return null;
        }

        #endregion


    }
}
