using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.GeoManagementCore.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CM.GeoManagementCore.WebApp.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ValidationException))
            {
                context.ExceptionHandled = true;
                context.Result = new BadRequestObjectResult(new ErrorModel()
                {
                    Title = context.Exception.Message
                });
            }
            if (context.Exception.GetType() == typeof(NotFoundException))
            {
                context.ExceptionHandled = true;
                context.Result = new NotFoundObjectResult(new ErrorModel()
                {
                    Title = context.Exception.Message
                });
            }
            else
            {
                context.ExceptionHandled = true;
                context.Result = new ObjectResult(
                    new ErrorModel()
                    {
                        Title = context.Exception.Message,
                    })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            base.OnException(context);
        }
    }
}
