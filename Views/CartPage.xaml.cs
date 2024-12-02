using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class CartPage : ContentPage
    {
        public CartPage(MedicationService service)
        {
            InitializeComponent();
            BindingContext = new CartViewModel(service); // S�tt ViewModel f�r sidan 
        }
    }
}
