using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class CartPage : ContentPage
    {
        public CartPage(MedicationService service)
        {
            InitializeComponent();
            BindingContext = new CartViewModel(service); // Sätt ViewModel för sidan 
        }
    }
}
