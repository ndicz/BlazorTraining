using R_BlazorFrontEnd.Controls.Events;
using SAB00100Model;

namespace SAB00100Front
{
    public partial class SAB00100
    {
        private SAB00100ViewModel ViewModel = new();

        public void R_Before_Open_Find(R_BeforeOpenFindEventArgs eventArgs)
        {
            eventArgs.TargetPageType = typeof(SAB00110);

        }

        public void R_After_Open_Find(R_AfterOpenFindEventArgs eventArgs)
        {

        }

    }
}