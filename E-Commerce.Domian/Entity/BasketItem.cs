namespace E_Commerce.Domian.Entity
{
    public class BasketItem
    {
        public BasketItem() { }
        public BasketItem(int productId, string productName, decimal price, int quantity, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
    }
}