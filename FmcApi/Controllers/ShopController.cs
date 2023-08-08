using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpPost]
        [Route("saveshop")]
        public async Task SaveShop(EntShop ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@city",ebo.city),
                new SqlParameter("@area",ebo.area),
                new SqlParameter("@location",ebo.location),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@logurl",ebo.logurl),
                 new SqlParameter("@coverimageurl",ebo.coverimageurl),
                new SqlParameter("@isactive",ebo.isactive),
                new SqlParameter("@businessdescription",ebo.businessdescription)

                };
                await MyCrud.CRUD("sp_InsertShop", sp);
            }
        }

        [HttpDelete]
        [Route("deleteshop/{shopid}")]
        public async Task DeleteShop(int shopid)
        {
            if (shopid != -1)
            {
                SqlParameter[] sp = {
                new SqlParameter("@shopid",shopid)
                };
                await MyCrud.CRUD("sp_DeleteShop", sp);
            }
        }


        [HttpPut]
        public async Task UpdateShop(EntShop ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@boid",ebo.boid),
                new SqlParameter("@city",ebo.city),
                new SqlParameter("@area",ebo.area),
                new SqlParameter("@location",ebo.location),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@logurl",ebo.logurl),
                 new SqlParameter("@coverimageurl",ebo.coverimageurl),
                new SqlParameter("@isactive",ebo.isactive),
                new SqlParameter("@businessdescription",ebo.businessdescription)

                };
                await MyCrud.CRUD("sp_UpdateShop", sp);
            }
        }

        [HttpGet]

        public async Task<JsonResult> GetShop()
        {
            List<EntShop> entBusinessOwners = new List<EntShop>();
            entBusinessOwners = await DalShop.GetShop();
            return new JsonResult(entBusinessOwners);
        }
    }
}
