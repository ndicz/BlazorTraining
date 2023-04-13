using R_BackEnd;
using SAB00400Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_APICommonDTO;
using R_CommonFrontBackAPI;
using R_BlazorFrontEnd.Exceptions;

namespace SAB00400Back
{
    internal class SAB00410Cls : R_BusinessObject<SAB00410DTO>
    {
        protected override SAB00410DTO R_Display(SAB00410DTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override void R_Saving(SAB00410DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            throw new NotImplementedException();
        }

        protected override void R_Deleting(SAB00410DTO poEntity)
        {
            throw new NotImplementedException();
        }

        public List<SAB00410DTO> GetAllTerritory()
        {
            var loEx = new R_APIException();
            List<SAB00410DTO> loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ORDER BY TerritoryID";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public List<SAB00410DTO> GetTerritoryByRegionID(int piRegionID)
        {
            var loEx = new R_APIException();
            var loResult = new List<SAB00410DTO>();

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = "SELECT * FROM Territories (NOLOCK) ";
                lcQuery += $"WHERE RegionID = {piRegionID}";
                loResult = loDb.SqlExecObjectQuery<SAB00410DTO>(lcQuery, loConn, true);
            }
            catch (Exception ex)
            {
                loEx.add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}
