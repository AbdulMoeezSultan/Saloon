using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalServices
    {
        public static async Task<List<EntServices>> GetServices()
        {
            try
            {
                using(SqlConnection con=DBHelper.GetConnection()) 
                {
                    await con.OpenAsync();
                    using(SqlCommand cmd=new SqlCommand("GetServices", con)) 
                    {
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        SqlDataReader sdr= await cmd.ExecuteReaderAsync();
                        List<EntServices> listServices = new List<EntServices>();
                        while(sdr.Read()) 
                        {
                            EntServices ebw= new EntServices();
                            ebw.serviceid = int.Parse(sdr["serviceid"].ToString());
                            ebw.shopid = int.Parse(sdr["shopid"].ToString());
                            ebw.servicename = sdr["servicename"].ToString();
                            ebw.price = int.Parse(sdr["price"].ToString());
                            ebw.isactive = sdr.GetBoolean(sdr.GetOrdinal("isactive"));
                           listServices.Add(ebw);
                        }

                        await con.CloseAsync();
                        return listServices;
                    }
                }
            }
            catch {
                return null;
            }
        }
    }
}
