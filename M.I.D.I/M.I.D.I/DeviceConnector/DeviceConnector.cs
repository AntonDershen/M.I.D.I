using Microsoft.Maker.Firmata;
using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        List<DeviceInformations> devices;
        DeviceWatcher deviceWatcher;

        public void InitializeDevices()
        {
            var aqs = GetAQS(15);
            deviceWatcher = DeviceInformation.CreateWatcher(aqs);
            deviceWatcher.Added += DeviceWatcher_Added; ;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            devices = new List<DeviceInformations>();
            deviceWatcher.Start();
        }
        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate device)
        {
            await this.dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var removeDevice = devices.FirstOrDefault(x => x.DeviceInformation.Id == device.Id);
                DevicePanel.Children.Remove(removeDevice.StackPanel);
                devices.Remove(removeDevice);
            });
        }
        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation device)
        {
            await this.dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 StackPanel stackPanel = AddingStackPanel(device.Id);
                 DevicePanel.Children.Add(stackPanel);
                 DeviceInformations deviceInformations = new DeviceInformations(device, null, stackPanel);
                 devices.Add(deviceInformations);
             });
        }
        private StackPanel AddingStackPanel(string name)
        {
            StackPanel stackPanel = new StackPanel();
            Button button = new Button();
            stackPanel.Name = name;
            button.FontSize = 25;
            button.Width = 50;
            button.Height = 50;
            button.Foreground = new SolidColorBrush(Colors.White);
            button.Background = new SolidColorBrush(Colors.Transparent);

            SymbolIcon symbolIcon = new SymbolIcon();
            symbolIcon.Symbol = Symbol.Calculator;
            button.Content = symbolIcon;

            stackPanel.Name = name;
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(button);
            return stackPanel;
        }
        private string GetAQS(int deviceCount)
        {
            string aqs = string.Empty;

            for (int i = 0; i < deviceCount; i++)
            {
                aqs += "(" + SerialDevice.GetDeviceSelector("COM" + i);
                if (i != deviceCount - 1)
                {
                    aqs += ") OR ";
                }
                else
                {
                    aqs += ")";
                }
            }
            return aqs;
        }

    }
    public class DeviceInformations
    {
        public DeviceInformation DeviceInformation { get; private set; }
        public RemoteDevice RemoteDevice { get; private set; }
        public StackPanel StackPanel { get; private set; }

        public DeviceInformations(DeviceInformation deviceInformation,
            RemoteDevice remoteDevice, StackPanel stackPanel)
        {
            this.DeviceInformation = deviceInformation;
            this.RemoteDevice = remoteDevice;
            this.StackPanel = stackPanel;
        }
    }
}
