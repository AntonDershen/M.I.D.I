using Windows.UI.Xaml.Controls;
using M.I.D.I.Infrastructure;
using M.I.D.I.DataModels;
namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        DependencyResolver dependencyResolver;
        public MainPage()
        {
            this.InitializeComponent();
            dependencyResolver = new DependencyResolver();
        }
    }
}
