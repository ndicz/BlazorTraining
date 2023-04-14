using R_BusinessObjectFront;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using SAB00400Common;
using SAB00400Common.DTOs;

namespace SAB00400Model
{
    public class SAB00410Model : R_BusinessObjectServiceClientBase<SAB00410DTO>, ISAB00410
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_SERVICEPOINT_NAME = "api/SAB00410";

        public SAB00410Model(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_SERVICEPOINT_NAME,
            bool plSendWithContext = true,
            bool plSendWithToken = false)
            : base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00400ListDTO<SAB00410DTO> GetAllTerritory()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00410DTO>> GetAllTeritoryAsync()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;
            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loRtn = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00410DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00410.GetAllTerritory),
                    _SendWithContext,
                    _SendWithToken);
                    
            }
            catch (Exception ex)
            {
               loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

    }
}
