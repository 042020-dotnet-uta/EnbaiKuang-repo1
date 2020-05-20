using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RevatrueP1.Models
{
    public class Product
    {
        private int productID;
        private int storeID;
        private Store store;

        [Display(Name = "Product")]
        private string productName;
        private int quantity;

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        private decimal price;
        public ICollection<Order> Orders { get; set; }

        #region getset
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public int StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }
        public Store Store
        {
            get { return store; }
            set { store = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }
}
