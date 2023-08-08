using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessOwnerController : ControllerBase
    {
        [HttpPost]
        [Route("savebo")]
        public async Task SaveOwnerInfo(EntBusinessOwner ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@emailadress",ebo.emailadress),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@isactive",ebo.isactive)

                };
                await MyCrud.CRUD("InsertBusinessOwner", sp);
            }
        }

        [HttpDelete]
        [Route("deleteowner/{BOId}")]
        public async Task DeleteOwnerInfo(int BOId)
        {
            if (BOId != 0)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",BOId)
                };
                await MyCrud.CRUD("DeleteBusinessOwner", sp);
            }
        }


        [HttpPut]
        public async Task UpdateOwnerInfo(EntBusinessOwner ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@emailadress",ebo.emailadress),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@isactive",ebo.isactive)
                };
                await MyCrud.CRUD("UpdateBusinessOwner", sp);
            }
        } 
        [HttpGet]
        [Route("getowners")]
        public async Task<JsonResult> GetOwners()
        {
            List<EntBusinessOwner> entBusinessOwners = new List<EntBusinessOwner>();
            entBusinessOwners = await DalBusinessOwner.GetBusinessOwners();
            return new JsonResult(entBusinessOwners);
        }

    }
}
