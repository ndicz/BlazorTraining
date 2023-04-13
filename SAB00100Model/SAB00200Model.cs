using System;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using R_CommonFrontBackAPI;using SAB00100Common;
using SAB00100Common.DTOs;


namespace SAB00200Model
{
    public class SAB00200Model : R_BusinessObjectServiceClientBase<SAB00100DTO>, ISAB00100
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00100";

        public SAB00200Model(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = true) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00100ListEmployeeDTO> GetAllEmployeeAsync()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeDTO loResult = null;

            try
            {
                R_HTTPClientWrapper.httpClientName = DEFAULT_HTTP_NAME;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00100ListEmployeeDTO>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00100),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

    }
}
