using BpMeter.Application.Abstractions;

namespace BpMeter.UI
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App(IPersonalInformationService service)
        {
            InitializeComponent();

            Task.Run(service.InitializeAsync).Wait();

            MainPage = new AppShell();
        }
    }
}
