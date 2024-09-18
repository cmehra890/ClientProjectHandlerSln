using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Admin;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.DAL
{
    public class AdminDAL : IAdminDAL
    {
        public async Task<ProjectSubmissionModel> GetProjectSubmission(string submissionId)
        {
            ProjectSubmissionModel responseModel = new();
            List<CommentModel> comments = [];
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    DynamicParameters dyParam = new DynamicParameters();
                    dyParam.Add("@IP_SUBMISSION_ID", submissionId, DbType.String, ParameterDirection.Input, int.MaxValue);

                    using (var reader = await db.QueryMultipleAsync("GetClientProjectSubmissionDetails", dyParam, commandType: CommandType.StoredProcedure))
                    {
                        responseModel = await reader.ReadSingleAsync<ProjectSubmissionModel>();

                        comments = (await reader.ReadAsync<CommentModel>()).ToList();
                    }

                    responseModel.ProjectComments = comments;

                    return responseModel;
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProjectSubmissionModel>> GetProjectSubmissions(AdminDashboardModel model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    DynamicParameters dyParam = new DynamicParameters();
                    dyParam.Add("@IP_CLIENT_NAME", model.ClientName, DbType.String, ParameterDirection.Input, 200);
                    dyParam.Add("@IP_TYPE_OF_PROJECT", model.ClientTypeOfProject, DbType.String, ParameterDirection.Input, 500);

                    var list = await db.QueryAsync<ProjectSubmissionModel>("ListOfClientSubmissions", dyParam, commandType: CommandType.StoredProcedure);

                    return list.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ErrorModel> PostCommentOnProjectSubmission(CommentModel model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    DynamicParameters dyParam = new DynamicParameters();

                    dyParam.Add("@IP_SUBMISSION_ID",model.SubmissionID,DbType.String,ParameterDirection.Input,10);
                    dyParam.Add("@@IP_SYSTEM_USER_ID", model.CommentedBy,DbType.String,ParameterDirection.Input,10);
                    dyParam.Add("@IP_COMMENT", model.CommentText,DbType.String,ParameterDirection.Input,int.MaxValue);

                    int affectedRows = await db.ExecuteAsync("PostCommentOnProjectSubmission", dyParam, commandType: CommandType.StoredProcedure);

                    if (affectedRows != 1)
                    {
                        return new ErrorModel
                        {
                            ErrorCode = "-1",
                            ErrorDescription = "Problem occured while attempting to post the comment!",
                            NoOfRowsEffected = affectedRows
                        };
                    }
                    return new ErrorModel
                    {
                        ErrorCode = "0",
                        ErrorDescription = "Comment posted successfully!",
                        NoOfRowsEffected = affectedRows
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
