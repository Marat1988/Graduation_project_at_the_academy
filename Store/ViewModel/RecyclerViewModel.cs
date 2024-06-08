using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ViewModel
{
    public class RecyclerViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal DisplayPrice { get; set; }
        public decimal ShippingPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Total => Amount * ShippingPrice;
    }
}