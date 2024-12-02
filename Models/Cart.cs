using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Cart
    {
        public ObservableCollection<CartItem> Items { get; private set; } = new ObservableCollection<CartItem>();

        public void AddToCart(Medication medication, int quantity)
        {
            var existingItem = Items.FirstOrDefault(c => c.Medication.Name == medication.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Medication = medication, Quantity = quantity });
            }
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            Items.Remove(cartItem);
        }

        public decimal Total => Items.Sum(item => item.Total);
    }
}
