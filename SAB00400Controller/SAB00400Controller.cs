using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Back;
using SAB00400Common;
using SAB00400Common.DTOs;

namespace SAB00400Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00400Controller : ControllerBase, ISAB00400
    {
        [HttpPost]
        public R_ServiceGetRecordResultDTO<SAB00400DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00400DTO> poParameter)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public R_ServiceSaveResultDTO<SAB00400DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00400DTO> poParameter)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00400DTO> poParameter)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public SAB00400ListDTO<SAB00400DTO> GetAllRegion()
        {
            var loEx = new R_Exception();
            SAB00400ListDTO<SAB00400DTO> loRtn = null;

            try
            {
                var loCls = new SAB00400Cls();

                var loResult = loCls.GetRegions();
                loRtn = new SAB00400ListDTO<SAB00400DTO> { Data = loResult };
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