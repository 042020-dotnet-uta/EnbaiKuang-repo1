using System;
using System.ComponentModel.DataAnnotations;


namespace RevatrueP1.Models
{
    public class Order
    {
        private int orderID;

        [Display(Name = "Product ID")]
        [Required]
        private int productID;

        [Display(Name = "Product")]
        private Product product;

        [Display(Name = "User ID")]
        [Required]
        private int userID;

        [Display(Name = "User")]
        private User user;

        [Display(Name = "Quantity")]
        [Required]
        private int quantity;

        private DateTime timestamp = DateTime.Now;
        [Display(Name = "Date/Time")]
        public DateTime Timestamp
        {
            get { return timestamp; }
        }

        private int storeID;

        public int StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }

        #region getset
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion
    }
}
