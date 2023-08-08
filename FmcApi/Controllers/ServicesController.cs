using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        [HttpPost]
        [Route("saveservice")]
        public async Task SaveServices(EntServices ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@serviceid",ebo.serviceid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@servicename",ebo.servicename),
                new SqlParameter("@price",ebo.price),
                new SqlParameter("@isactive",ebo.isactive)

                };
                await MyCrud.CRUD("sp_InsertServices", sp);
            }
        }

        [HttpDelete]
        [Route("deleteservice/{serviceid}")]
        public async Task DeleteServices(int serviceid)
        {
            if (serviceid != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@serviceid",serviceid)
                        };
                await MyCrud.CRUD("sp_DeleteServices", sp);
            }
        }




        [HttpPut]
        public async Task UpdatServices(EntServices ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@serviceid",ebo.serviceid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@servicename",ebo.servicename),
                new SqlParameter("@price",ebo.price),
                new SqlParameter("@isactive",ebo.isactive)
                };
                await MyCrud.CRUD("sp_UpdateServices", sp);
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetServices()
        {
            List<EntServices> entEmployee = new List<EntServices>();
            entEmployee = await DalServices.GetServices();
            return new JsonResult(entEmployee);
        }

    

    }
}
