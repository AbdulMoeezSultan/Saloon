using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntBusinessOwner
    {
        public int boid { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? emailadress { get; set; }
        public string? phone { get; set; }
        public string? cnic { get; set; }
        public bool isactive { get; set; }
        public DateTime creationdatetime { get; set; }

    }
}
