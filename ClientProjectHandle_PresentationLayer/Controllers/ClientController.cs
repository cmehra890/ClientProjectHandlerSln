using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_PresentationLayer.Filters.AuthorizationFilters;
using Microsoft.AspNetCore.Mvc;

namespace ClientProjectHandle_PresentationLayer.Controllers
{
    [ClientAuthorizationFilter]
    public class ClientController : Controller
    { 
        private readonly IClientBLL _clientBLL;

        public ClientController(IClientBLL clientBLL) 
        { 
            _clientBLL = clientBLL;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _clientBLL.GetTypeOfProject();

            ViewBag.TypeOfProjectList = list;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ClientSubmissionViewModel model)
        {
            try
            {


                return Ok(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet]
        //public async Task<JsonResult> GetTypeOfProjectsOptions()
        //{
        //    try
        //    {
        //        var obj = await _clientBLL.GetTypeOfProject();

        //        return Json(obj);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }

}
