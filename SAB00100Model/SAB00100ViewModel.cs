using R_BlazorFrontEnd;
using SAB00100Common.DTOs;

public class SAB00100ViewModel : R_ViewModel<SAB00100DTO>
{
    private SAB00100Model.SAB00100Model _model = new SAB00100Model.SAB00100Model();
    public SAB00100DTO Employee = new SAB00100DTO();
}