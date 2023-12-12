using Enternet_Shop.Infrastructure.Mappers;
using Enternet_Shop.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternet_Shop.Infrastructure.Database
{
    public class ShoppingCartRepository
    {
        public List<ShoppingCartViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Products.ToList();
                return ShoppingCartMapper.Map(items);
            }
        }
        public ShoppingCartViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Products.FirstOrDefault(x => x.ID == id);
                return ShoppingCartMapper.Map(item);
            }
        }
        public static void AddToCart(long productId)
        {
            using (var context = new Context())
            {
                var product = context.Products.FirstOrDefault(x => x.ID == productId);
                if (product != null)
                {
                    var cartItem = ShoppingCartMapper.Map(product);
                    ShoppingCartStorage.AddItem(cartItem);
                }
            }
        }
    }
    public static class ShoppingCartStorage
    {
        private static List<ShoppingCartViewModel> _cartItems = new List<ShoppingCartViewModel>();

        public static List<ShoppingCartViewModel> GetItems()
        {
            return _cartItems;
        }

        public static void AddItem(ShoppingCartViewModel item)
        {
            var existingItem = _cartItems.FirstOrDefault(x => x.ID == item.ID);
            if (existingItem != null)
            {
                existingItem.Quanity++;
            }
            else
            {
                _cartItems.Add(item);
            }
        }

        public static void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
