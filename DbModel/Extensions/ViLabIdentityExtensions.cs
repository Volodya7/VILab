using System;
using System.Collections.Generic;
using System.Text;
using DbModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbModel.Extensions
{
    public static class ViLabIdentityExtensions
    {
        public static void AddIdentityExt(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ViLabContext>();
        }
    }
}
