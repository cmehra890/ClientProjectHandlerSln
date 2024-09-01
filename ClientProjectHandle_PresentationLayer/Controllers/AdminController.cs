using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_Entities.Admin;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_PresentationLayer.Filters.AuthorizationFilters;
using Microsoft.AspNetCore.Mvc;

namespace ClientProjectHandle_PresentationLayer.Controllers
{
	[AdminAuthorizationFilter]
	public class AdminController : Controller
	{
		private readonly IAdminBLL _adminBLL;
		public AdminController(IAdminBLL adminBLL) 
		{ 
			_adminBLL = adminBLL;
		}

		public async Task<IActionResult> Index()
		{
			AdminDashboardModel model = new AdminDashboardModel();

			model = await _adminBLL.GetAdminDashboardModel(model);
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Index(AdminDashboardModel model)
		{
            model = await _adminBLL.GetAdminDashboardModel(model);

            return View(model);
        }

		//[HttpGet]
		

	}
}
