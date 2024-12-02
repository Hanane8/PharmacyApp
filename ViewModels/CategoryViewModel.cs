using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PharmacyApp.Services;
using PharmacyApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace PharmacyApp.ViewModels
{
    public partial class CategoryViewModel : ObservableObject
    {
        private readonly MedicationService _service;

        public ObservableCollection<Medication> Medications { get; }

        public RelayCommand<Medication> AddToCartCommand
        {
            get; private set;
        }

        public CategoryViewModel(MedicationService service, Category? selectedCategory = null)
        {
            _service = service;

            if (selectedCategory != null)
            {
                Medications = _service.GetMedicationsByCategory(selectedCategory.Name);
            }
            else
            {
                // Visa alla mediciner som standard
                Medications = new ObservableCollection<Medication>(_service.Medications);
            }

            AddToCartCommand = new RelayCommand<Medication>(AddToCart);
        }

        //private void AddToCart(Medication medication)
        //{
        //    _service.Cart.AddToCart(medication,1);
        //}

        private async void AddToCart(Medication medication)
        {
            if (medication == null) return;

            _service.Cart.AddToCart(medication, 1);
            await Shell.Current.DisplayAlert("Läkemedel tillagd till kundvagnen!", "", "OK");

            // Navigera till CartPage
            await Shell.Current.GoToAsync("//CartPage", new Dictionary<string, object> { { "service", _service } });
        }
    }

    

}
