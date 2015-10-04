using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Internal;
using Microsoft.Net.Http.Headers;

namespace Demo04.Filters
{
    public class BananaRequiredFilter : ActionFilterAttribute
    {
        private string _requiredKeyword;
        public BananaRequiredFilter(string requiredKeyWord = "banana")
        {
            _requiredKeyword = requiredKeyWord;
            Order = 1000;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.HttpContext.Request.Query.ContainsKey(_requiredKeyword))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 418,
                    Content = String.Format("Sorry, no {0} here", _requiredKeyword)
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
