using ClientProjectHandle_PresentationLayer.Filters.AuthorizationFilters;
using Microsoft.AspNetCore.Mvc;

namespace ClientProjectHandle_PresentationLayer.Controllers
{
	[AdminAuthorizationFilter]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
