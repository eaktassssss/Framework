using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
 

namespace Framework.Business.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                context.Controller.ViewData.ModelState.AddModelError(null,context.Exception.Message);
                context.ExceptionHandled = true;
                context.Result = new ViewResult
                {
                    ViewData = new ViewDataDictionary(context.Controller.ViewData)
                };
            }
            return;
        }
    }

}
