using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00100Common.DTOs;

namespace SAB00100Model
{
    public class SAB00200ViewModel : R_ViewModel<SAB00100DTO>
    {
        private SAB00100Model _modelGrid = new SAB00100Model();

        public ObservableCollection<SAB00100GridDTO> EmployeeList { get; set; } = new ObservableCollection<SAB00100GridDTO>();

        public SAB00100DTO Employee { get; set; } = new SAB00100DTO();


        public async Task GetEmployeeList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _modelGrid.GetAllEmployeeAsync();
                EmployeeList = new ObservableCollection<SAB00100GridDTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task SaveEmployee(SAB00100DTO poNewEntity, eCRUDMode peCRUDMode)
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _modelGrid.R_ServiceSaveAsync(poNewEntity, peCRUDMode);

                Employee = loResult;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }


        public async Task DeleteEmployee(int emp)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00100DTO { EmployeeID = emp};
                await _modelGrid.R_ServiceDeleteAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
