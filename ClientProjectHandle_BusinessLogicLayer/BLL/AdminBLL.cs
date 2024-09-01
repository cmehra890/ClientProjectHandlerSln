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

                 list.ForEach(x => {
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
    }
}
