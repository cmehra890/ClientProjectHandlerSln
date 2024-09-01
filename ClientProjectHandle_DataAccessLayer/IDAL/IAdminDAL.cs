using ClientProjectHandle_Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.IDAL
{
    public interface IAdminDAL
    {
        Task<List<ProjectSubmissionModel>> GetProjectSubmissions(AdminDashboardModel model);
    }
}
