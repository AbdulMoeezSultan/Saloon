using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntServices
    {
        public int serviceid { get; set; }
        public int shopid { get; set; }

        public string? servicename { get; set; }

        public double price { get; set; }

        public bool isactive { get; set; }
    }
}
