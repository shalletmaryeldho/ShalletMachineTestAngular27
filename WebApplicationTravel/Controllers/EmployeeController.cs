using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTravel.Models;
using WebApplicationTravel.Repository;

namespace WebApplicationTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployee employee;
        public EmployeeController(IEmployee _t)
        {
            employee = _t;
        }
        #region HttpGet

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var requests = await employee.GetEmployees();
                if (requests == null)
                {
                    return NotFound();
                }
                return Ok(requests);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion

        #region HttpPost
        [HttpPost]
        [Route("AddEmployees")]
        public async Task<IActionResult> AddEmployees([FromBody] Registration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var EmpId = await employee.AddEmployees(model);
                    if (EmpId != null)
                    {
                        return Ok(EmpId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }




        #endregion

        #region UpdateEmployees
        //update food
        [HttpPut]
        [Route("UpdateEmployees")]
        public async Task<IActionResult> UpdateEmployees([FromBody] Registration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employee.UpdateEmployees(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

    }
}
