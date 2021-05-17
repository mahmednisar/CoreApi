using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Services;
using CoreApi.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApi.Core
{
    public class BindDependency
    {
        public BindDependency(IServiceCollection services)
        {
            //services.AddScoped<IStudentServices, StudentServices>();
            //services.AddTransient<IStudentServices, StudentServices>();
            services.AddSingleton<IStudentServices, StudentServices>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
