using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_DataAccessLayer.LoginDAL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_Entities.LoginAndSignup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_BusinessLogicLayer.BLL
{
    public class LoginBLL : ILoginBLL
    {
        private readonly ILoginDAL _loginDAL;

        public LoginBLL()
        {
            _loginDAL = new LoginDAL();
        }

        public async Task<LoginDetailModel> CheckUserExistence(string? userName, string? password)
        {
            try
            {
                if(userName != null && password != null)
                {
                    return await _loginDAL.CheckUserExistence(userName, password);
                }
                return new LoginDetailModel() { ErrorCode = "-1",ErrorDescription = "Username or password cannot be empty!" };
            }
            catch (Exception) 
            {
                throw;
            }
        }

    }
}
