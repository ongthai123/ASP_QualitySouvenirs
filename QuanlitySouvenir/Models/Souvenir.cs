using System;
using System.Collections.Generic;

namespace QuanlitySouvenir.Models
{
    public class Souvenir
    {
   

        public int SouvenirID { get; set; }
        public String Name { get; set; }
        public float Price { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }//url

        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
    }
}
