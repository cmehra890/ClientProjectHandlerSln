using ClientProjectHandle_BusinessLogicLayer.IBLL;
using ClientProjectHandle_DataAccessLayer.DAL;
using ClientProjectHandle_DataAccessLayer.IDAL;
using ClientProjectHandle_Entities.Client;
using ClientProjectHandle_Entities.Global;
using ClientProjectHandle_Utilities;
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

        public async Task<ErrorModel> InsertClientSubmissionDetails(ClientSubmissionViewModel model)
        {
            try
            {
                if (model.ClientFirstName is not null &&
                    model.ClientLastName is not null &&
                    model.ClientEmail is not null &&
                    model.ClientBusinessAddress is not null &&
                    model.ClientPhoneNumber is not null &&
                    model.ClientProjectOverview is not null &&
                    model.ClientProjectType is not null)
                {
                    ErrorModel response = await _clientDAL.InsertClientSubmissionDetails(model);

                    if (response is { ErrorCode: "0" })
                    {
                        await Mailer.SendMail(new MailModel
                        {
                            To = model.ClientEmail,
                            Subject = "Project Submission Recieved!",
                            Body = "We have recieved your project synopsis submission in our system!",
                        });

                        return new ErrorModel()
                        {
                            ErrorCode = response.ErrorCode,
                            ErrorDescription = "Project submitted successfully!"
                        };
                    }
                }
                return new ErrorModel()
                {
                    ErrorCode = "-1",
                    ErrorDescription = "Submission model contains null values!"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
