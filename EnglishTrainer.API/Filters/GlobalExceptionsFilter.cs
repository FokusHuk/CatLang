using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EnglishTrainer.API.Filters
{
    public class GlobalExceptionsFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(context.Exception.Message);
            
            context.ExceptionHandled = true;
        }
    }
}