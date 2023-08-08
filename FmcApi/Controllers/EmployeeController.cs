using DAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace FmcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [Route("saveemployee")]
        public async Task SaveEmployee(EntEmployee ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@empid",ebo.empid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@joiningdate",ebo.joiningdate),
                new SqlParameter("@enddate",ebo.enddate),
                new SqlParameter("@emptype",ebo.emptype),
                new SqlParameter("@padress",ebo.padress),
                new SqlParameter("@tadress",ebo.tadress),
                new SqlParameter("@dob",ebo.dob),

                new SqlParameter("@isactive",ebo.isactive)

                };
                await MyCrud.CRUD("sp_InsertEmployee", sp);
            }
        }

        [HttpDelete]
        [Route("deleteemployee/{empid}")]
        public async Task DeleteEmployee(int empid)
        {
            if (empid != 0)
            {
                SqlParameter[] sp = {
                        new SqlParameter("@empid",empid)
                        };
                await MyCrud.CRUD("sp_DeleteEmployee", sp);
            }
        }

        [HttpPut]
        public async Task UpdateEmployee(EntEmployee ebo)
        {
            if (ebo != null)
            {
                SqlParameter[] sp = {
                new SqlParameter("@empid",ebo.empid),
                new SqlParameter("@shopid",ebo.shopid),
                new SqlParameter("@firstname",ebo.firstname),
                new SqlParameter("@lastname",ebo.lastname),
                new SqlParameter("@phone",ebo.phone),
                new SqlParameter("@cnic",ebo.cnic),
                new SqlParameter("@joiningdate",ebo.joiningdate),
                new SqlParameter("@enddate",ebo.enddate),
                new SqlParameter("@emptype",ebo.emptype),
                new SqlParameter("@padress",ebo.padress),
                new SqlParameter("@tadress",ebo.tadress),
                new SqlParameter("@dob",ebo.dob),

                new SqlParameter("@isactive",ebo.isactive)

                };
                await MyCrud.CRUD("sp_UpdateEmployee", sp);
            }
        }

        [HttpGet]

        public async Task<JsonResult> GetEmployee()
        {
            List<EntEmployee> entEmployee = new List<EntEmployee>();
            entEmployee = await DalEmployee.GetEmployee();
            return new JsonResult(entEmployee);
        }

    }
 }