using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class DalShop
    {
        public static async Task<List<EntShop>> GetShop()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("sp_GetShops", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                        List<EntShop> listOwners = new List<EntShop>();
                        while (sdr.Read())
                        {
                            EntShop ebw = new EntShop();
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.boid = int.Parse(sdr["boid"].ToString());
                            ebw.city = sdr["city"].ToString();
                            ebw.area = sdr["area"].ToString();
                            ebw.phone = sdr["phone"].ToString();
                            ebw.location = sdr["location"].ToString();
                            ebw.logurl = sdr["logurl"].ToString();
                            ebw.coverimageurl = sdr["coverimageurl"].ToString();
                            ebw.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));
                            ebw.businessdescription = sdr["businessdescription"].ToString();

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
