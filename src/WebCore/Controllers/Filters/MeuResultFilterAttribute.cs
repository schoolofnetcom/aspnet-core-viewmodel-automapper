using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Controllers.Filters
{
    public class MeuResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //Executa algo antes da Action
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //Executa algo depois da Action
        }
    }
}
