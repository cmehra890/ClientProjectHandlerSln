using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Admin;
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
        public async Task<List<ProjectSubmissionModel>> GetProjectSubmissions(AdminDashboardModel model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    DynamicParameters dyParam = new DynamicParameters();
                    dyParam.Add("@IP_CLIENT_NAME", model.ClientName,DbType.String ,ParameterDirection.Input, 200);
                    dyParam.Add("@IP_TYPE_OF_PROJECT", model.ClientTypeOfProject,DbType.String ,ParameterDirection.Input, 500);

                    var list = await db.QueryAsync<ProjectSubmissionModel>("ListOfClientSubmissions",dyParam,commandType:CommandType.StoredProcedure);

                    return list.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
