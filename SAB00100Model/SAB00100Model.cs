using System;
using System.Threading.Tasks;
using R_BusinessObjectFront;
using R_CommonFrontBackAPI;
using SAB00100Common;
using SAB00100Common.DTOs;

namespace SAB00100Model
{
    public class SAB00100Model : R_BusinessObjectServiceClientBase<SAB00100DTO>, ISAB00100
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00100";




        public SAB00100Model(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) 
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task <SAB00100ListEmployeeDTO> GetEmployeeAync()
        {


        }

    }
}
    