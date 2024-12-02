using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class MedicationPage : ContentPage
    {
        public MedicationPage(MedicationService service, Medication medication)
        {
            InitializeComponent();
            // Pass the medication's name (or other relevant string) instead of the full medication object
            BindingContext = new MedicationViewModel(service, medication.Name); // Assuming the name is the expected argument
        }
    }

}
