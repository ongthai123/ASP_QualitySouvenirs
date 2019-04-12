using System;
namespace QuanlitySouvenir.Models
{
    public class Customer
    {
  
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public String Address { get; set; }
        public Boolean Enabled { get; set; }
    }
}
