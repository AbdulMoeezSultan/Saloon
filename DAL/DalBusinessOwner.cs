using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalBusinessOwner
    {
        public static async Task<List<EntBusinessOwner>> GetBusinessOwners()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetBusinessOwners", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                       SqlDataReader sdr= await cmd.ExecuteReaderAsync();
                        List<EntBusinessOwner> listOwners = new List<EntBusinessOwner>(); 
                        while (sdr.Read())
                        {
                            EntBusinessOwner ebw = new EntBusinessOwner();
                            ebw.boid =int.Parse(sdr["boid"].ToString());
                            ebw.firstname = sdr["firstname"].ToString();
                            ebw.lastname = sdr["lastname"].ToString() ;
                            ebw.emailadress = sdr["emailadress"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.cnic = sdr["cnic"].ToString();
           
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
