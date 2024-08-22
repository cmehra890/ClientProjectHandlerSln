using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_Entities.LoginAndSignup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_BusinessLogicLayer.IBLL
{
    public interface ILoginBLL
    {
        Task<LoginDetailModel> CheckUserExistence(string? userName, string? password);
    }
}
