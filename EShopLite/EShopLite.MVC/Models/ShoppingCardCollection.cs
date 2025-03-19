using EShopLite.Application.DataTransferObjects;

namespace EShopLite.MVC.Models
{
    public class ShoppingCardCollection
    {
        public List<ShoppingCardItem> Items { get; set; } = new List<ShoppingCardItem>();

        public void Add(ShoppingCardItem productItem)
        {
            var shoppingCardItem = Items.FirstOrDefault(x => x.ProductItem.ProductId == productItem.ProductItem.ProductId);
            if (shoppingCardItem == null)
            {
                Items.Add(new ShoppingCardItem { ProductItem = productItem.ProductItem, Quantity = 1 });
            }
            else
            {
                shoppingCardItem.Quantity += 1;
            }
        }

        public void Remove(ProductItemForBasket productItem)
        {
            var shoppingCardItem = Items.FirstOrDefault(x => x.ProductItem.ProductId == productItem.ProductId);
            Items.Remove(shoppingCardItem);
        }

        public void Clear() => Items.Clear();

        public decimal TotalPrice => Items.Sum(x => x.ProductItem.Price * x.Quantity);
        public int TotalItems => Items.Sum(x => x.Quantity);


    }

    public class ShoppingCardItem
    {
        public ProductItemForBasket ProductItem { get; set; }
        public int Quantity { get; set; }


    }

}
