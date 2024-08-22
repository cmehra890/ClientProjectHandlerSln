using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientProjectHandle_PresentationLayer.Filters.AuthorizationFilters
{
    public class AdminAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!(context.HttpContext.Session.GetString("SYSTEM_ROLE") == "ADMIN"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
