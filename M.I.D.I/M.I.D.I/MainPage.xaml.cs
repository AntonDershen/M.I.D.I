using Windows.UI.Xaml.Controls;
using M.I.D.I.Infrastructure;
using M.I.D.I.DataModels;
using Windows.Devices.SerialCommunication;
using Windows.ApplicationModel.Core;
using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;

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

        private void LED_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            devices[0].RemoteDevice.digitalWrite(13, PinState.HIGH);
        }

        private void LEDOFF_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            devices[0].RemoteDevice.digitalWrite(13, PinState.LOW);
        }
    }
}
