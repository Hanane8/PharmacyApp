using System.Collections.ObjectModel;
using PharmacyApp.Models;
using PharmacyApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PharmacyApp.Views;
using System.Threading.Tasks;

namespace PharmacyApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly MedicationService _service;

        // Kategorier att visa på hemsidan
        public ObservableCollection<Category> Categories => _service.Categories;

        // Den valda kategorin
        [ObservableProperty]
        private Category selectedCategory;

        partial void OnSelectedCategoryChanged(Category value)
        {
            if (value != null)
            {
                NavigateToCategoryPageCommand.Execute(value);
            }
        }
        [RelayCommand]
        private async Task NavigateToCategoryPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CategoryPage(_service, SelectedCategory!));
        }



        // Konstruktor
        public HomeViewModel(MedicationService service)
        {
            _service = service;
        }
    }
}
