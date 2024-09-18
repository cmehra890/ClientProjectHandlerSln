using ClientProjectHandle_Entities.Admin;
using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_BusinessLogicLayer.IBLL
{
    public interface IAdminBLL
    {
        Task<AdminDashboardModel> GetAdminDashboardModel(AdminDashboardModel model);
        Task<Tuple<ErrorModel, ProjectSubmissionModel>> GetProjectSubmission(string submissionId);
        Task<ErrorModel> PostCommentOnProjectSubmission(string submissionId, string commentedById, string commentText);
    }
}
