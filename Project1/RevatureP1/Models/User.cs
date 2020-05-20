using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RevatrueP1.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        private int userID;

        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        private string firstName;

        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2)]
        [Required]
        private string lastName;
        public ICollection<Order> Orders;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
