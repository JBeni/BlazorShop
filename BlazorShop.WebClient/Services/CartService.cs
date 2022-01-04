using static BlazorShop.WebClient.Pages.Other;

namespace BlazorShop.WebClient.Services
{
    public class CartService
    {
        public void EmptyCart()
        {
        }

        public List<CartItem> GetCartItems()
        {
            return new List<CartItem>();
        }

        public void DeleteItem(CartItem item)
        {
        }
    }
}
