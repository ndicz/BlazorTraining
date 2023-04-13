using R_APICommonDTO;
using R_BackEnd;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00400Common.DTOs;

namespace SAB00400Back
{

    // DI BACK R_APIException
    // FRONT R_Exception
    public class SAB00400Cls : R_BusinessObject<SAB00400DTO>
    {
        protected override SAB00400DTO R_Display(SAB00400DTO poEntity)
        {
            var loEx = new R_APIException();
            SAB00400DTO loResult = null;

            try
            {
                var loDb = new R_Db();
                var loConn = loDb.GetConnection("NorthwindConnectionString");

                var lcQuery = $"SELECT * FROM Region (NOLOCK) WHERE RegionID = {poEntity.RegionID}";
                loResult = loDb.SqlExecObjectQuery<SAB00400DTO>(lcQuery, loConn, true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                loEx.add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        protected override void R_Deleting(SAB00400DTO poEntity)
        {
            throw new NotImplementedException();
        }

        protected override void R_Saving(SAB00400DTO poNewEntity, eCRUDMode poCRUDMode)
        {
            throw new NotImplementedException();
        }

        public List<SAB00400DTO> GetRegions()
        {
            {
                var loEx = new R_Exception();
                List<SAB00400DTO> loResult = null;
                try
                {
                    var loDb = new R_Db();
                    var loConn = loDb.GetConnection("NorthwindConnectionString");

                    var lcQuery = $"SELECT * FROM Region (NOLOCK)";
                    loResult = loDb.SqlExecObjectQuery<SAB00400DTO>(lcQuery, loConn, true);
                }
                catch (Exception ex)
                {
                    loEx.Add(ex);
                }

                loEx.ThrowExceptionIfErrors();
                return loResult;
            }


        }
    }
}


