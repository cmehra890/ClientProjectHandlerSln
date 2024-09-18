using ClientProjectHandle_Entities.Admin;
using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.IDAL
{
    public interface IAdminDAL
    {
        Task<List<ProjectSubmissionModel>> GetProjectSubmissions(AdminDashboardModel model);
        Task<ProjectSubmissionModel> GetProjectSubmission(string submissionId);
        Task<ErrorModel> PostCommentOnProjectSubmission(CommentModel model);
    }
}
