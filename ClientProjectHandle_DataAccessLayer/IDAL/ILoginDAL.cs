using ClientProjectHandle_Entities.LoginAndSignup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.IDAL
{
    public interface ILoginDAL
    {
        Task<LoginDetailModel> CheckUserExistence(string userName, string password);
    }
}
