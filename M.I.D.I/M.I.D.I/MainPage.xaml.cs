using Windows.UI.Xaml.Controls;
using M.I.D.I.Infrastructure;
using M.I.D.I.DataModels;
using Windows.Devices.SerialCommunication;
using Windows.ApplicationModel.Core;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        DependencyResolver dependencyResolver;
        Windows.UI.Core.CoreDispatcher dispatcher;

        public MainPage()
        {
            dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
            this.InitializeComponent();
            this.InitializeDevices();
            dependencyResolver = new DependencyResolver();
        }

    }
}
