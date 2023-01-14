using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_SEC_P.Models
{
    public class RequestParameterModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Sorting { get; set; }
    }
}
