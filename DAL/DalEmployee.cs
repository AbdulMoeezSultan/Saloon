using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalEmployee
    {
        public static async Task<List<EntEmployee>> GetEmployee()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntEmployee> listOwners = new List<EntEmployee>();
                        while (sdr.Read())
                        {
                            EntEmployee ebw = new EntEmployee();
                            ebw.empid = int.Parse(sdr["empid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString();
                            ebw.emptype = sdr["emptype"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.dob = sdr["dob"].ToString();
                            ebw.padress = sdr["padress"].ToString();
                            ebw.tadress = sdr["tadress"].ToString();
                            ebw.joiningdate = sdr["joiningdate"].ToString();
                            ebw.enddate = sdr["enddate"].ToString();
                            ebw.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));

                            listOwners.Add(ebw);

                        }
                        await con.CloseAsync();
                        return listOwners;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}




