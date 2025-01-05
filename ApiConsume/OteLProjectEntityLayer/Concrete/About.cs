using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OteLProjectEntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Content { get; set; }
        public int RoomsCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCunt { get; set; }
    }
}
