using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_DataAccessLayer.DAL;
using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Admin;
using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_BusinessLogicLayer.BLL
{
    public class AdminBLL : IAdminBLL
    {
        private readonly IAdminDAL _adminDAL;
        private readonly IClientDAL _clientDAL;

        public AdminBLL()
        {
            _adminDAL = new AdminDAL();
            _clientDAL = new ClientDAL();
        }

        public async Task<AdminDashboardModel> GetAdminDashboardModel(AdminDashboardModel model)
        {
            try
            {
                var list = await _clientDAL.GetTypeOfProject();

                list.ForEach(x =>
                {
                    model.ClientTypeOfProjectList.Add(new DropDownModel { Text = x, Value = x });
                });

                model.ProjectSubmissions = await _adminDAL.GetProjectSubmissions(model);

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Tuple<ErrorModel, ProjectSubmissionModel>> GetProjectSubmission(string submissionId)
        {
            ErrorModel errorModel = new() { ErrorCode = "0" };
            try
            {
                if (submissionId is null)
                {
                    errorModel.ErrorCode = "-1";
                    errorModel.ErrorDescription = "Submission id cannot be null!";

                    return Tuple.Create(errorModel, new ProjectSubmissionModel());
                }

                var response = await _adminDAL.GetProjectSubmission(submissionId);

                return Tuple.Create(errorModel, response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ErrorModel> PostCommentOnProjectSubmission(string submissionId, string commentedById, string commentText)
        {
            CommentModel model = new() { SubmissionID = submissionId, CommentedBy = commentedById, CommentText = commentText };
            try
            {
                if (string.IsNullOrEmpty(model.SubmissionID))
                {
                    return new ErrorModel()
                    {
                        ErrorCode = "-2",
                        ErrorDescription = "Submission id cannot be null or empty!"
                    };
                }
                if (string.IsNullOrEmpty(model.CommentedBy))
                {
                    return new ErrorModel()
                    {
                        ErrorCode = "-2",
                        ErrorDescription = "User id cannot be null or empty!"
                    };
                }
                if (string.IsNullOrEmpty(model.CommentText))
                {
                    return new ErrorModel()
                    {
                        ErrorCode = "-2",
                        ErrorDescription = "Comment text cannot be null or empty!"
                    };
                }

                var response = await _adminDAL.PostCommentOnProjectSubmission(model);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
