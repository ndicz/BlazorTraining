using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front
{
    public partial class SAB00100
    {
        private SAB00100ViewModel _viewModel = new();
        private R_Conductor conductRef;

        private R_Grid<SAB00100GridDTO> _gridRef;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridRef.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        public async Task R_ServiceGetListRecordAsync(R_ServiceGetListRecordEventArgs eventArgs)
        {
            R_Exception loEx = new();
            try
            {
                await _viewModel.GetAllEmployeeAsync();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(SAB00110);
        }

        public async Task R_After_Open_FindAsync(R_AfterOpenFindEventArgs eventArgs)
        {
            var loData = eventArgs.Result;

            await conductRef.R_GetEntity(loData);
        }

        public async Task R_ServiceGetRecordAsync(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();
            try
            {
                //var loData = (SAB00100GridDTO)eventArgs.Data;
                var loData = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);

                await _viewModel.GetEmployeeAsync(loData.EmployeeID);

                eventArgs.Result = _viewModel.Employee;

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

        public void R_Validation(R_ValidationEventArgs eventArgs)
        {
            R_Exception loEx = new();

            try
            {
                _viewModel.SaveValidation((SAB00100DTO)eventArgs.Data);

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            if (loEx.HasError)
            {
                eventArgs.Cancel = true;
            }
            //eventArgs.Cancel = loEx.HasError;

            loEx.ThrowExceptionIfErrors();

        }

        public async Task R_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();

            try
            {
                await _viewModel.SaveEmployee(
                    (SAB00100DTO)eventArgs.Data,
                    (eCRUDMode)eventArgs.ConductorMode);

                eventArgs.Result = _viewModel.Employee;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task R_AfterSaveAsync(R_AfterSaveEventArgs eventArgs)
        {
            var loData = (SAB00100DTO)eventArgs.Data;

            await R_MessageBox.Show("", $"Save {loData.FirstName} {loData.LastName} success.", R_eMessageBoxButtonType.OK);
        }

        private void R_AfterAdd(R_AfterAddEventArgs eventArgs)
        {
            var loDefault = new SAB00100DTO()
            {
                Address = "Sentul",
                City = "Bogor",
                Country = "Indonesia"
            };
        }

        private async Task R_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            R_Exception loEx = new R_Exception();

            try
            {
                await _viewModel.DeleteEmploye((SAB00100DTO)eventArgs.Data);

            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }
            loEx.ThrowExceptionIfErrors();
        }

    }
}

