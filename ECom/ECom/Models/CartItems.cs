using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


        //nav properties 
        public Cart Cart { get; set; }
        public Product Product { get; set; }

    }
}
