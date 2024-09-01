using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_Utilities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ClientProjectHandle_DataAccessLayer.DAL
{
    public class ClientDAL : IClientDAL
    {
        public async Task<List<string>> GetTypeOfProject()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    var response = await db.QueryAsync<string>("GetClientAreaOfSpecialization", null, commandType: CommandType.StoredProcedure);

                    db.Close();

                    return response.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ErrorModel> InsertClientSubmissionDetails(ClientSubmissionViewModel model)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();
                    DynamicParameters dyParam = new DynamicParameters();

                    dyParam.Add("@IP_CLIENT_FIRST_NAME", model.ClientFirstName, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_LAST_NAME", model.ClientLastName, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_EMAIL", model.ClientEmail, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_PHONE_NUMBER", model.ClientPhoneNumber, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_BUSINESS_ADDRESS", model.ClientBusinessAddress, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_PROJECT_OVERVIEW", model.ClientProjectOverview, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_CLIENT_AREA_OF_SPECIAL", model.ClientProjectType, DbType.String, ParameterDirection.Input);

                    int response = await db.ExecuteAsync("InsertClientSubmissionDetails", dyParam, commandType: CommandType.StoredProcedure);

                    db.Close();

                    if (!(response > 0))
                    {
                        return new ErrorModel
                        {
                            ErrorCode = "-1",
                            ErrorDescription = "Error While Inserting Client Project Synopsis Details",
                            NoOfRowsEffected = response
                        };
                    }

                    return new ErrorModel
                    {
                        ErrorCode = "0",
                        ErrorDescription = "Successfullly Submitted!",
                        NoOfRowsEffected = response
                    };
                }
            }
            catch (Exception ex)
            {
                return new ErrorModel { ErrorCode = "500", ErrorDescription = ex.Message };
            }
        }


    }
}
