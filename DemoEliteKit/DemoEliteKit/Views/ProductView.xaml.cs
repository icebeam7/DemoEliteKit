using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoEliteKit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductView : ContentPage
    {
        public ProductView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            badge.BadgeView = new Image()
            {
                Source = ImageSource.FromResource("DemoEliteKit.Images.box.png"),
                HeightRequest = 50,
                WidthRequest = 50
            };
        }
    }
}