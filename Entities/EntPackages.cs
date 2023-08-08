using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntPackages
    {
        public int packageid { get; set; }
        public int shopid { get; set; }

        public string? packagename { get; set; }
        public string? services { get; set; }
        public int price { get; set; }
    }
}
