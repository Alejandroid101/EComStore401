using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECom.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string CartId { get; set; }

        //nav properties 
        //public ICollection<CartItems> CartItems { get; set; }
    }
}
