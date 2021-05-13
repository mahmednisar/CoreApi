using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Dto;

namespace CoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public Student CurrentStudent{get { return new Student() {ID = 1, Contact = "7894561230", SName = "ABC"}; }}

    }
}
