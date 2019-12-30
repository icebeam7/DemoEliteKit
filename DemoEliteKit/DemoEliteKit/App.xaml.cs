using Xamarin.Forms;

namespace DemoEliteKit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.ProductView();
        }
    }
}
