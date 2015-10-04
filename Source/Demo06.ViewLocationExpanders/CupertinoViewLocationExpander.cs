using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo06.ViewLocationExpanders
{
    public class CupertinoViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            // we don't want to change layout pages & partials ...
            if (context.IsPartial) return viewLocations;

            var descriptor = (context.ActionContext.ActionDescriptor as ControllerActionDescriptor);
            if (descriptor == null) { return viewLocations; }

            if (descriptor.ControllerName == "Home" && context.ActionContext.ActionDescriptor.Name == "Contact"
                && context.ActionContext.HttpContext.Request.Query.ContainsKey("apple"))
            {
                return viewLocations.Select(x => x.Replace("{0}", "Special/{0}"));
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // we add this to enable caching! 
            var contains = context.ActionContext.HttpContext.Request.Query.ContainsKey("apple");
            context.Values.Add("CupertinoKey", contains.ToString());
        }
    }
}
