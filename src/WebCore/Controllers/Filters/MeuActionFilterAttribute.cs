using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers.Filters
{
    public class MeuActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executa algo antes da Action
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executa algo depois da Action
        }
    }
}
