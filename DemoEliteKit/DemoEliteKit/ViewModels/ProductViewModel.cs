using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;

using Acr.UserDialogs;

namespace DemoEliteKit.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private string headerImage;

        public string HeaderImage
        {
            get { return headerImage; }
            set { headerImage = value; OnPropertyChanged(); }
        }

        private string footerImage;

        public string FooterImage
        {
            get { return footerImage; }
            set { footerImage = value; OnPropertyChanged(); }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }

        private int productStock;

        public int ProductStock
        {
            get { return productStock; }
            set { productStock = value; OnPropertyChanged(); }
        }

        private bool discontinued;

        public bool Discontinued
        {
            get { return discontinued; }
            set { discontinued = value; OnPropertyChanged(); }
        }

        private bool isTechnology;

        public bool IsTechnology
        {
            get { return isTechnology; }
            set { isTechnology = value; OnPropertyChanged(); }
        }

        private bool isFood;

        public bool IsFood
        {
            get { return isFood; }
            set { isFood = value; OnPropertyChanged(); }
        }

        private int saveProgress;

        public int SaveProgress
        {
            get { return saveProgress; }
            set { saveProgress = value; OnPropertyChanged(); }
        }

        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { private set; get; }
        public ICommand ValidateCommand { private set; get; }

        public ProductViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
            ValidateCommand = new Command(() => Validate());

            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            IsBusy = true;
            IsValid = false;

            await Task.Delay(5000);

            HeaderImage = "xamarin.png";
            FooterImage = "monkey.png";

            IsBusy = false;
        }

        private void Validate()
        {
            IsValid = !string.IsNullOrEmpty(ProductName);
        }

        private async Task Register()
        {
            SaveProgress = 0;

            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                SaveProgress += 20;
            }

            var alert = new AlertConfig()
            {
                Message = $"Name: {ProductName} \nCategory: {(IsFood ? "Food" : IsTechnology ? "Technology" : "N/A" )} \nStock: {ProductStock} \nDiscontinued? {Discontinued}",
                Title = "Product Details",
                OkText = "Great!"
            };

            await UserDialogs.Instance.AlertAsync(alert);
        }
    }
}