using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_Entities.LoginAndSignup;
using ClientProjectHandle_PresentationLayer.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace ClientProjectHandle_PresentationLayer.Controllers
{
    [SkipSessionCheck]
    public class LoginController : Controller
	{
		private readonly ILoginBLL _loginBLL;
		private readonly IHttpContextAccessor _contextAccessor;

		public LoginController(ILoginBLL loginBLL,IHttpContextAccessor contextAccessor)
		{
			_loginBLL = loginBLL;
			_contextAccessor = contextAccessor;
		}

		public IActionResult Index()
		{
			_contextAccessor?.HttpContext?.Session.Clear();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginModel? model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var response = await _loginBLL.CheckUserExistence(model?.UserName,model?.Password);

					if(response.ErrorCode == "0")
					{
						_contextAccessor?.HttpContext?.Session.SetString("USER_ID",response?.RoleId);
						_contextAccessor?.HttpContext?.Session.SetString("SYSTEM_ROLE",response?.SystemRole);

						if(response.SystemRole == "ADMIN")
						{
							return RedirectToAction("Index", "Admin");
						}
						else if (response.SystemRole == "CLIENT")
                        {
                            return RedirectToAction("Index", "Client");
                        }
                    }
				}

				ViewBag.ErrorMessage = "Kindly Fill Required Details!!!";
				return RedirectToAction("Index", "Login");
			}
			catch (Exception) 
			{
				throw;
			}
		}
	}
}
