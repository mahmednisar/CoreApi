using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Dto
{
    public  class UserDto
    {
        public int Id{ get; set; }
        public string UsrFirstName { get; set; }
        public string UsrMiddleName { get; set; }
        public string UsrLastName { get; set; }
        public string Usercode{ get; set; }
        public string UsrMobNo { get; set; }
        public string UsrEmail { get; set; }
        public string Token { get; set; }
    }
}
