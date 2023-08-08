using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntEmployee
    {
        public int empid { get; set; }
        public int shopid { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? phone { get; set; }

        public string? dob { get; set; }
        public string? cnic { get; set; }
        public string? padress { get; set; }
        public string? tadress { get; set; }
        public string? emptype { get; set; }
        public string? joiningdate { get; set; }
        public string? enddate { get; set; }

        public bool isactive { get; set; }

    }
}
