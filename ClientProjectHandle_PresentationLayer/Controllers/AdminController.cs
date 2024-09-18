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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currentUserId;
        public AdminController(IAdminBLL adminBLL,IHttpContextAccessor httpContextAccessor)
        {
            _adminBLL = adminBLL;
            _httpContextAccessor = httpContextAccessor;
            _currentUserId = Convert.ToString(_httpContextAccessor.HttpContext.Session.GetString(SessionVariablesModel.SessionUserId) ?? string.Empty);
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

        [HttpPost]
        public async Task<JsonResult> GetProjectDetails(string submissionId)
        {
            try
            {
                var (errorModel, projectDetailModel) = await _adminBLL.GetProjectSubmission(submissionId);

                if (errorModel.ErrorCode != "0") throw new Exception(errorModel.ErrorDescription);

                return Json(projectDetailModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> PostCommentOnProject(string submissionId,string comment)
        {
            try
            {
                var response = await _adminBLL.PostCommentOnProjectSubmission(submissionId, _currentUserId, comment);
                return Json(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
