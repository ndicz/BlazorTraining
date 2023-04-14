using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Exceptions;
using SAB00400Common.DTOs;

namespace SAB00400Model.ViewModel
{
    public class SAB00400ViewModel : R_ViewModel<SAB00400DTO>
    {
        private SAB00400Model _SAB00400Model = new SAB00400Model();

        public ObservableCollection<SAB00400DTO> RegionList { get; set; } = new ObservableCollection<SAB00400DTO>();

        public SAB00400DTO Region = new SAB00400DTO();

        public async Task GetRegionList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _SAB00400Model.GetAllRegionAsync();
                RegionList = new ObservableCollection<SAB00400DTO>(loResult.Data);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
