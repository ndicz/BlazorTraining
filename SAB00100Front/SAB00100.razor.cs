using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Controls.DataControls;
using R_BlazorFrontEnd.Controls.Events;
using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd.Helpers;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;
using SAB00100Model;

namespace SAB00100Front;

public partial class SAB00100
{
    private SAB00100ViewModel _viewModel = new();
    private R_Conductor _rConductorRef;

    #region FindEmployee

    public void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
    {
        eventArgs.TargetPageType = typeof(SAB00110);
    }

    public async Task R_After_Open_Find(R_AfterOpenFindEventArgs eventArgs)
    {
        var loData = eventArgs.Result;
        await _rConductorRef.R_GetEntity(loData);
    }

    #endregion

    private async Task R_ServiceGetRecordAsync(R_ServiceGetRecordEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            //var loData = (SAB00100GridDTO)eventArgs.Data;
            var loData = R_FrontUtility.ConvertObjectToObject<SAB00100DTO>(eventArgs.Data);
            await _viewModel.GetEmployeeAsync(loData.EmployeeID);

            eventArgs.Result = _viewModel.Employee;
        }
        catch (Exception e)
        {
            loEx.Add(e);
        }

        loEx.ThrowExceptionIfErrors();
    }

    private void R_Validation(R_ValidationEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            _viewModel.SaveValidation((SAB00100DTO)eventArgs.Data);
        }
        catch (Exception e)
        {
            loEx.Add(e);
        }

        eventArgs.Cancel = loEx.HasError;

        loEx.ThrowExceptionIfErrors();
    }

    private async Task R_ServiceSaveAsync(R_ServiceSaveEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            var loParam = (SAB00100DTO)eventArgs.Data;
            var loMode = (eCRUDMode)eventArgs.ConductorMode;
            await _viewModel.SaveEmployeeAsync(loParam, loMode);

            eventArgs.Result = _viewModel.Employee;
        }
        catch (Exception e)
        {
            loEx.Add(e);
        }

        loEx.ThrowExceptionIfErrors();
    }

    public async Task R_ServiceDeleteAsync(R_ServiceDeleteEventArgs eventArgs)
    {
        var loEx = new R_Exception();

        try
        {
            var loParam = (SAB00100DTO)eventArgs.Data;
            await _viewModel.DeleteEmployee(loParam);
        }
        catch (Exception ex)
        {
            loEx.Add(ex);
        }

        loEx.ThrowExceptionIfErrors();
    }
}