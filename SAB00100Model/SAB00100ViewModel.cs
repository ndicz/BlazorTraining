using System;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100FrontResources;


namespace SAB00100Model
{
    public class SAB00100ViewModel : R_ViewModel<SAB00100DTO>
    {
        private SAB00100Model _model = new SAB00100Model();
        public SAB00100DTO Employee = new SAB00100DTO();

        public async Task GetEmployeeAsync(int piEmployeeId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00100DTO() { EmployeeID = piEmployeeId };
                var loResult = await _model.R_ServiceGetRecordAsync(loParam);

                Employee = loResult;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public void SaveValidation(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();

            try
            {
                if (string.IsNullOrWhiteSpace(poEntity.FirstName))
                {
                    var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS001");
                    loEx.Add(loErr);
                }

                if (string.IsNullOrWhiteSpace(poEntity.LastName))
                {
                    var loErr = R_FrontUtility.R_GetError(typeof(Resources_Dummy_Class), "PS002");
                    loEx.Add(loErr);
                }
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveEmployeeAsync(SAB00100DTO poEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.R_ServiceSaveAsync(poEntity, peCRUDMode);
                Employee = loResult;
            }
            catch (Exception e)
            {
                loEx.Add(e);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task DeleteEmployee(SAB00100DTO poEntity)
        {
            var loEx = new R_Exception();
            try
            {
                await _model.R_ServiceDeleteAsync(poEntity);

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }
    }


}