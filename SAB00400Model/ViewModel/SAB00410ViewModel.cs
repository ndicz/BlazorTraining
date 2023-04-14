using R_BlazorFrontEnd;
using System;
using System.Collections.Generic;
using System.Text;
using SAB00400Common.DTOs;
using R_BlazorFrontEnd.Exceptions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00400Model.ViewModel
{
    public class SAB00410ViewModel : R_ViewModel<SAB00410DTO>
    {
        private SAB00410Model _SAB00410Model = new SAB00410Model();

        public ObservableCollection<SAB00410DTO> TerritoresList { get; set; } = new ObservableCollection<SAB00410DTO>();

        public SAB00410DTO Region = new SAB00410DTO();

        public async Task GetRegionList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00410Model.GetAllTeritoryAsync();
                TerritoresList = new ObservableCollection<SAB00410DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
