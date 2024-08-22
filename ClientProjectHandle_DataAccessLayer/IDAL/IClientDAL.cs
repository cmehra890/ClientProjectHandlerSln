using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_DataAccessLayer.IDAL
{
    public interface IClientDAL
    {
        Task<ErrorModel> InsertClientSubmissionDetails(ClientSubmissionViewModel model);
        Task<List<string>> GetTypeOfProject();
    }
}
