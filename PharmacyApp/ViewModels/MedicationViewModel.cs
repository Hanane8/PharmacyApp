using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using PharmacyApp.Services;
using PharmacyApp.Models;

namespace PharmacyApp.ViewModels
{
    public partial class MedicationViewModel : ObservableObject
    {
        private readonly MedicationService _service;

        [ObservableProperty]
        private ObservableCollection<Medication> medications;

        public MedicationViewModel(MedicationService service, string categoryName)
        {
            _service = service;
            Medications = _service.GetMedicationsByCategory(categoryName);
        }

        [RelayCommand]
        private void AddToCart(Medication medication)
        {
            _service.Cart.AddToCart(medication, 1);
        }
    }

}
