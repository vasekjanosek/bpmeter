using BpMeter.Application.Abstractions;

namespace BpMeter.UI
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(IPersonalInformationService service)
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
