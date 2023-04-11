using R_BlazorFrontEnd.Exceptions;
using R_BlazorFrontEnd;
using SAB00100Common.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

public class SAB00110ViewModel : R_ViewModel<SAB00100DTO>
{
    private SAB00100Model.SAB00100Model _model = new SAB00100Model.SAB00100Model();
    public SAB00100DTO Employee = new SAB00100DTO();
    public ObservableCollection<SAB00100GridDTO> EmployeeList = new ObservableCollection<SAB00100GridDTO>();
    public async Task GetAllEmployeAsync()
    {
        var loEx = new R_Exception();
        try
        {
            var loResult = await _model.GetAllEmployeeAsync();
            EmployeeList = new ObservableCollection<SAB00100GridDTO>(loResult.Data);
        }
        catch (Exception e)
        {
            loEx.Add(e);
        }
        loEx.ThrowExceptionIfErrors();
    }

}