using PharmacyApp.Models;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;

namespace PharmacyApp.Views
{
    public partial class CategoryPage : ContentPage
    {
        private readonly MedicationService _service;

        public CategoryPage(MedicationService service, Category? selectedCategory = null)
        {
            InitializeComponent();

            _service = service;

            BindingContext = new CategoryViewModel(_service, selectedCategory);
        }
    }

}

