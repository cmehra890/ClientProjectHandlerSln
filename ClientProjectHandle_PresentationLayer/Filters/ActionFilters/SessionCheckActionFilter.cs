using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientProjectHandle_PresentationLayer.Filters.ActionFilters
{
    public class SkipSessionCheck : Attribute, IFilterMetadata
    {

    }

    public class SessionCheckActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.Filters.OfType<SkipSessionCheck>().Any())
            {
                doSessionCheck(context.HttpContext);
            }
        }

        private void doSessionCheck(HttpContext context) 
        {
            try
            {
                if (context.Session.GetString("USER_ID") == null)
                {
                    context.Session.Clear();
                    context.Response.Redirect("/Client/Index");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
