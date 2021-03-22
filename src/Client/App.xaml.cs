using System.Windows;
using Client.Startup;

namespace Client
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();      
            bootstrapper.Run(); 
            base.OnStartup(e);
        }
    }
}