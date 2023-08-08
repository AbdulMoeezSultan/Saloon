using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PackagesController : ControllerBase
        {
            [HttpPost]
        [Route("savepackage")]
        public async Task SavePackage(EntPackages ebo)
            {
                if (ebo != null)
                {
                    SqlParameter[] sp = {
                new SqlParameter("@packageid",ebo.packageid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@packagename",ebo.packagename),
                new SqlParameter("@servicename",ebo.services),
                new SqlParameter("@price",ebo.price)

                };
                    await MyCrud.CRUD("sp_InsertPackage", sp);
                }
            }

        [HttpDelete]
        [Route("deletepackage/{packageid}")]
        public async Task DeletePackage(int packageid)
        {
            if (packageid != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@packageid",packageid)
                        };
                await MyCrud.CRUD("sp_DeletePackages", sp);
            }
        }




        [HttpPut]
            public async Task UpdatPackage(EntPackages ebo)
            {
                if (ebo != null)
                {
                    SqlParameter[] sp = {
                new SqlParameter("@packageid",ebo.packageid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@packagename",ebo.packagename),
                new SqlParameter("@servicename",ebo.services),
                new SqlParameter("@price",ebo.price)
                };
                    await MyCrud.CRUD("sp_UpdatePackage", sp);
                }
            }


            [HttpGet]

            public async Task<JsonResult> GetPackage()
            {
                List<EntPackages> entEmployee = new List<EntPackages>();
                entEmployee = await DalPackages.GetPackages();
                return new JsonResult(entEmployee);
            }

        }
    }
