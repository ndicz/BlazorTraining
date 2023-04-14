using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_APICommonDTO;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00400Back;
using SAB00400Common;
using SAB00400Common.DTOs;
namespace SAB00400Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00410Controller : ControllerBase, ISAB00410 
    {
        [HttpPost]
        public R_ServiceGetRecordResultDTO<SAB00410DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00410DTO> poParameter)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public R_ServiceSaveResultDTO<SAB00410DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00410DTO> poParameter)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00410DTO> poParameter)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpPost]
        public SAB00400ListDTO<SAB00410DTO> GetAllTerritory()
        {
            var loEx = new R_APIException();
            SAB00400ListDTO<SAB00410DTO> loRtn = null;

            try
            {
                var loCls = new SAB00410Cls();

                var loResult = loCls.GetAllTerritory();
                loRtn = new SAB00400ListDTO<SAB00410DTO> { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}
