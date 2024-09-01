using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_PresentationLayer.Filters.ActionFilters;
using ClientProjectHandle_PresentationLayer.Filters.AuthorizationFilters;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ClientProjectHandle_PresentationLayer.Controllers
{
    //[ClientAuthorizationFilter]
    [SkipSessionCheck]
    public class ClientController : Controller
    {
        private readonly IClientBLL _clientBLL;
        private readonly IHttpContextAccessor _contextAccessor;

        public ClientController(IClientBLL clientBLL,IHttpContextAccessor contextAccessor)
        {
            _clientBLL = clientBLL;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            _contextAccessor?.HttpContext?.Session.Clear();
            _contextAccessor?.HttpContext?.Session.SetString("USER_ID", "0");
            _contextAccessor?.HttpContext?.Session.SetString("SYSTEM_ROLE", "CLIENT");

            var list = await _clientBLL.GetTypeOfProject();

            ViewBag.TypeOfProjectList = list;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ClientSubmissionViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ErrorModel = new ErrorModel { ErrorCode = "-2", ErrorDescription = "Data filled is not valid!" };
                    return View(model);
                }
                var response = await _clientBLL.InsertClientSubmissionDetails(model);

                if (response != null) 
                { 
                    if (response.ErrorCode == "0")
                    {
                        response.PreviousAction = "Index";
                        response.PreviousController = "Client";
                        return View("MessagePanel", response);
                    }
                }
                
                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
