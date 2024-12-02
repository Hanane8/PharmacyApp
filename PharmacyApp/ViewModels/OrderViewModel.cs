using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Models;
using static Microsoft.Maui.ApplicationModel.Permissions;
using PharmacyApp.Services;

namespace PharmacyApp.ViewModels
{
    public partial class OrderViewModel : ObservableObject
    {
        private readonly MedicationService _service;

        [ObservableProperty]
        private string customerName;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phone;

        public ObservableCollection<CartItem> Items => _service.Cart.Items;

        public decimal Total => CalculateTotal();

        public OrderViewModel(MedicationService service)
        {
            _service = service;
        }

        private decimal CalculateTotal()
        {
            return Items.Sum(item => item.Total);
        }

        [RelayCommand]
        private async Task PlaceOrderAsync()
        {
            if (string.IsNullOrWhiteSpace(CustomerName) ||
                string.IsNullOrWhiteSpace(Address) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Phone))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // Skapa en order
            var order = new Order
            {
                CustomerName = CustomerName,
                Address = Address,
                Email = Email,
                Phone = Phone,
                Items = new ObservableCollection<CartItem>(Items)
            };

            await App.Current.MainPage.DisplayAlert("Order Placed", "Your order has been placed successfully.", "OK");

            // Töm kundvagnen efter beställning
            Items.Clear();

            // Navigera tillbaka till huvudmenyn
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        partial void OnCustomerNameChanged(string value)
        {
            // Uppdatera något när CustomerName ändras, om nödvändigt.
        }
    }

}
