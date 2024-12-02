using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Services
{
    public class MedicationService
    {
        public ObservableCollection<Category> Categories { get; private set; }
        public ObservableCollection<Medication> Medications { get; private set; }
        public Cart Cart { get; private set; }

        public MedicationService()
        {
            // Initialisera kategorier
            Categories = new ObservableCollection<Category>
            {
            new Category { Name = "Painkillers", Image = "painkillers.jpg" },
            new Category { Name = "Antibiotics", Image = "antibiotics.jpg" },
            };

            // Initialisera läkemedel
            Medications = new ObservableCollection<Medication>
            {
            new Medication { Name = "Paracetamol", Description = "Pain reliever", Price = 49.99M, Category = "Painkillers", Image = "paracetamol.jpg" },
            new Medication { Name = "Ibuprofen", Description = "Anti-inflammatory", Price = 59.99M, Category = "Painkillers", Image = "ibuprofen.jpg" },
            new Medication { Name = "Amoxicillin", Description = "Antibiotic", Price = 99.99M, Category = "Antibiotics", Image = "amoxicillin.jpg" },
            };

            // Initialisera kundvagnen
            Cart = new Cart();
        }

        public ObservableCollection<Medication> GetMedicationsByCategory(string categoryName)
        {
            var medications = Medications.Where(m => m.Category == categoryName).ToList();
            return new ObservableCollection<Medication>(medications);
        }

    }
}
