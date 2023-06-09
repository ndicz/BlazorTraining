﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_APIClient;
using R_BlazorFrontEnd.Exceptions;
using R_BusinessObjectFront;
using R_CommonFrontBackAPI;
using SAB00400Common;
using SAB00400Common.DTOs;

namespace SAB00400Model
{
    public class SAB00400Model : R_BusinessObjectServiceClientBase<SAB00400DTO>, ISAB00400
    {
        private const string DEFAULT_HTTP_NAME = "R_DefaultServiceUrl";
        private const string DEFAULT_ENDPOINT = "api/SAB00400";
        public SAB00400Model(
            string pcHttpClientName = DEFAULT_HTTP_NAME,
            string pcRequestServiceEndPoint = DEFAULT_ENDPOINT,
            bool plSendWithContext = true,
            bool plSendWithToken = false) :
            base(pcHttpClientName, pcRequestServiceEndPoint, plSendWithContext, plSendWithToken)
        {
        }

        public SAB00400ListDTO<SAB00400DTO> GetAllRegion()
        {
            throw new NotImplementedException();
        }

        public async Task<SAB00400ListDTO<SAB00400DTO>> GetAllRegionAsync()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO <SAB00400DTO> loResult = null;
            try
            {
                R_HTTPClientWrapper.httpClientName = _HttpClientName;
                loResult = await R_HTTPClientWrapper.R_APIRequestObject<SAB00400ListDTO<SAB00400DTO>>(
                    _RequestServiceEndPoint,
                    nameof(ISAB00400.GetAllRegion),
                    _SendWithContext,
                    _SendWithToken);
            }
            catch (Exception ex )
            {
                loEx.Add(ex);
            }
           
            loEx.ThrowExceptionIfErrors();

            return loResult;
        }


    }
}