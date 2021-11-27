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
    public class TravelController : ControllerBase
    {
        ITravel travel;
        public TravelController(ITravel _t)
        {
            travel = _t;
        }
        #region HttpGet

        [HttpGet]
        [Route("GetRequests")]
        public async Task<IActionResult> GetRequests()
        {
            try
            {
                var requests = await travel.GetRequests();
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
        [Route("AddRequests")]
        public async Task<IActionResult> AddRequests([FromBody] RequestTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var requestId = await travel.AddRequests(model);
                    if (requestId != null)
                    {
                        return Ok(requestId);
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

        #region UpdateRequests
        //update food
        [HttpPut]
        [Route("UpdateRequests")]
        public async Task<IActionResult> UpdateRequests([FromBody] RequestTable model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await travel.UpdateRequests(model);
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

        #region GetAllRequests
      
        [HttpGet]
        [Route("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var requests = await travel.GetAllRequests();
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

    }
}
