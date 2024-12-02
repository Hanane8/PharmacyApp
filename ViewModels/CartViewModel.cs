using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using PharmacyApp.Models;
using PharmacyApp.Views;
using PharmacyApp.Services;

namespace PharmacyApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly MedicationService _service;

        // Kartan från tjänsten
        public ObservableCollection<CartItem> Items => _service.Cart.Items;

        // Beräknar totalkostnaden för kundvagnen
        public decimal Total => _service.Cart.Total;

        // Kommando för att ta bort en artikel från kundvagnen
        public CartViewModel(MedicationService service)
        {
            _service = service;

            // Initiera kommandot för ProceedToCheckout
            ProceedToCheckoutCommand = new AsyncRelayCommand(ProceedToCheckout);
        }

        // Kommandot för att ta bort artikel från kundvagnen
        [RelayCommand]
        private void RemoveFromCart(CartItem cartItem)
        {
            _service.Cart.RemoveFromCart(cartItem);
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(Total));
        }

        // Kommando för att gå vidare till kassasidan
        public IAsyncRelayCommand ProceedToCheckoutCommand { get; }

        private Task ProceedToCheckout()
        {
            // Navigera till OrderPage (kassasidan)
            return Application.Current.MainPage.Navigation.PushAsync(new OrderPage(_service));
        }
    }
}
