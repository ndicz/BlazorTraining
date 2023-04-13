using R_BlazorFrontEnd.Controls;
using R_BlazorFrontEnd.Controls.Base;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Controls.MessageBox;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front
{
    public partial class SAB00200 
    {
        private SAB00200ViewModel EmployeeViewModel = new();

        private R_ConductorGrid _conGridCustomerRef;

        private R_Grid<SAB00100GridDTO> _gridRef200;

        protected override async Task R_Init_From_Master(object poParameter)
        {
            var loEx = new R_Exception();

            try
            {
                await _gridRef200.R_RefreshGrid(null);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            R_DisplayException(loEx);
        }

        private async Task Grid_R_ServiceGetListRecord(R_ServiceGetListRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await EmployeeViewModel.GetEmployeeList();
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_ServiceGetRecord(R_ServiceGetRecordEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);
                await EmployeeViewModel.GetEmployeeList();

                eventArgs.Result = EmployeeViewModel.Employee;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private void Grid_BeforeEdit(R_BeforeEditEventArgs eventArgs)
        {
        }

        private void Grid_BeforeCancel(R_BeforeCancelEventArgs eventArgs)
        {
        }

        private void Grid_BeforeAdd(R_BeforeAddEventArgs eventArgs)
        {
        }

        private void Grid_AfterAdd(R_AfterAddEventArgs eventArgs)
        {
            eventArgs.Data = new SAB00100DTO
            {
                FirstName = "null",
                LastName = "null",
            };
        }

        private void Grid_Validation(R_ValidationEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00100GridDTO)eventArgs.Data;

                if (string.IsNullOrWhiteSpace(loData.FirstName))
                    loEx.Add("001", "Employee First NAme cannot be null.");
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            eventArgs.Cancel = loEx.HasError;

            loEx.ThrowExceptionIfErrors();
        }

        private void Grid_Saving(R_SavingEventArgs eventArgs)
        {
            if (eventArgs.ConductorMode == R_eConductorMode.Add)
            {
                var loData = (SAB00100GridDTO)eventArgs.Data;
                loData.FirstName = "Depok";
            }
        }

        private async Task Grid_ServiceSave(R_ServiceSaveEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                await EmployeeViewModel.SaveEmployee(
                    (SAB00100DTO)eventArgs.Data,
                    (eCRUDMode)eventArgs.ConductorMode);

                eventArgs.Result = EmployeeViewModel.EmployeeList;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_AfterSave(R_AfterSaveEventArgs eventArgs)
        {
            await R_MessageBox.Show("Success", "Success", R_eMessageBoxButtonType.OK);
        }

        private void Grid_BeforeDelete(R_BeforeDeleteEventArgs eventArgs)
        {
        }

        private async Task Grid_ServiceDelete(R_ServiceDeleteEventArgs eventArgs)
        {
            var loEx = new R_Exception();

            try
            {
                var loData = (SAB00100GridDTO)eventArgs.Data;
                await EmployeeViewModel.DeleteEmployee(loData.EmployeeID);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        private async Task Grid_AfterDelete()
        {
            await R_MessageBox.Show("Success", "Success Delete", R_eMessageBoxButtonType.OK);
        }

        private void R_Display()
        {
         
        }
    }
}
