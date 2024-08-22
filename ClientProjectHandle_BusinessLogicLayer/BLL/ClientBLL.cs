using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_DataAccessLayer.DAL;
using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_BusinessLogicLayer.BLL
{
    public class ClientBLL : IClientBLL
    {
        private IClientDAL _clientDAL;

        public ClientBLL()
        {
            _clientDAL = new ClientDAL();
        }

        public async Task<List<string>> GetTypeOfProject()
        {
            try
            {
                List<string> listOfTypeOfProjects = await _clientDAL.GetTypeOfProject();

                if (!(listOfTypeOfProjects.Count > 0))
                {
                    return new List<string>() { "" };
                }

                return listOfTypeOfProjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ErrorModel> InsertClientSubmissionDetails(ClientSubmissionViewModel model)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
