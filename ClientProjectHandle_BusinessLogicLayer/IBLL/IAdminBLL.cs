using ClientProjectHandle_Entities.Admin;
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
    }
}
