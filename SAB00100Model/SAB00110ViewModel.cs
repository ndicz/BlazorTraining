using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using R_BlazorFrontEnd.Exceptions;
using SAB00100Common.DTOs;

namespace SAB00100Model
{
    public class SAB00110ViewModel
    {
        private SAB00100Model _model = new SAB00100Model();
        public ObservableCollection<SAB00100GridDTO> EmployeeList = new ObservableCollection<SAB00100GridDTO>();
        public SAB00100DTO Employee = new SAB00100DTO();

        public async Task GetAllEmployeeAsync()
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
}