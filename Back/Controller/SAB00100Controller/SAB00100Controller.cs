﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R_Common;
using R_CommonFrontBackAPI;
using SAB00100Back;
using SAB00100Common;
using SAB00100Common.DTOs;

namespace SAB00100Controller
{
    [ApiController]
    [Route("api/[controller]/[action]"), AllowAnonymous]
    public class SAB00100Controller : ControllerBase, ISAB00100
    {
        [HttpPost]
        public R_ServiceDeleteResultDTO R_ServiceDelete(R_ServiceDeleteParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceDeleteResultDTO();

            try
            {
                var loCls = new SAB00100Cls();

                loCls.R_Delete(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceGetRecordResultDTO<SAB00100DTO> R_ServiceGetRecord(R_ServiceGetRecordParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceGetRecordResultDTO<SAB00100DTO>();

            try
            {
                var loCls = new SAB00100Cls();

                loRtn.data = loCls.R_GetRecord(poParameter.Entity);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public R_ServiceSaveResultDTO<SAB00100DTO> R_ServiceSave(R_ServiceSaveParameterDTO<SAB00100DTO> poParameter)
        {
            var loEx = new R_Exception();
            var loRtn = new R_ServiceSaveResultDTO<SAB00100DTO>();

            try
            {
                var loCls = new SAB00100Cls();

                loRtn.data = loCls.R_Save(poParameter.Entity, poParameter.CRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public SAB00100ListEmployeeDTO GetAllEmployee()
        {
            var loEx = new R_Exception();
            SAB00100ListEmployeeDTO loRtn = null;

            try
            {
                var loCls = new SAB00100Cls();

                var loResult = loCls.GetAllEmployee();
                loRtn = new SAB00100ListEmployeeDTO { Data = loResult };
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loRtn;
        }
        [HttpPost]
        public IAsyncEnumerable<SAB00100DTO> GetEmployeeStream()
        {
            var loEx = new R_Exception();
            IAsyncEnumerable<SAB00100DTO> loRtn = null;

            try
            {
                var loCls = new SAB00100Cls();
                var loResult = loCls.GetAllEmployeeStream();
                loRtn = GetEmpStream(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
            return loRtn;
        }

        private async IAsyncEnumerable<SAB00100DTO> GetEmpStream(List<SAB00100DTO> poParam)
        {
            foreach (SAB00100DTO item in poParam)
            {
                await Task.Delay(1000);
                yield return item;
            }
        }
    }
}