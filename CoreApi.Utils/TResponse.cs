using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi.Utils
{
    public class TResponse
    {
        public int ResponseCode{ get; set; }
        public bool ResponseStatus{ get; set; }
        public string ResponseMessage{ get; set; }
        public object ResponseData{ get; set; }
    }
}
