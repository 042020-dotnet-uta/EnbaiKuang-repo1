using System.Collections.Generic;

namespace RevatrueP1.Models
{
    public class Store
    {
        private int storeID;
        private string city;
        public ICollection<Product> Products { get; set; }

        public int StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
