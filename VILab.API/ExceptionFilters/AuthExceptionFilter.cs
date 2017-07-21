using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace VILab.API.ExceptionFilters
{
    public class AuthExceptionFilter:ExceptionFilterAttribute
    {
        private ILogger<AuthExceptionFilter> _logger;

        public AuthExceptionFilter()
        {
            
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
