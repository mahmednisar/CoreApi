using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.Dto;
using CoreApi.Utils;

namespace CoreApi.Services.Infrastructure
{
    public interface ILoginService
    {
        TResponse Login(LoginDto loginDto);
    }
}
