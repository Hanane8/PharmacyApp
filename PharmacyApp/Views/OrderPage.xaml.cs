

using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class OrderPage : ContentPage
    {
        public OrderPage(MedicationService service)
        {
            InitializeComponent();
            BindingContext = new OrderViewModel(service);
        }
    }

}
