using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.LoginAndSignup;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ClientProjectHandle_Utilities;

namespace ClientProjectHandle_DataAccessLayer.LoginDAL
{
    public class LoginDAL : ILoginDAL
    {
        public async Task<LoginDetailModel> CheckUserExistence(string userName, string password)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(DbConnection.GetConnectionString))
                {
                    db.Open();

                    DynamicParameters dyParam = new DynamicParameters();

                    dyParam.Add("@IP_USER_NAME", userName, DbType.String, ParameterDirection.Input);
                    dyParam.Add("@IP_PASSWORD", password, DbType.String, ParameterDirection.Input);

                    var response = await db.QueryAsync<LoginDetailModel>("CheckSystemUserExistence", dyParam, commandType: CommandType.StoredProcedure);

                    db.Close();

                    return response?.ToList().FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
