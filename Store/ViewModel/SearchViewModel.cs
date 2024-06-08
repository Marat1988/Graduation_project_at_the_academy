using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.ViewModel
{
    public class SearchViewModel
    {
        public decimal BeginPrice { get; set; }
        public decimal EndPrice { get; set; }
        public int GroupId { get; set; }
        public int SupplierId { get; set; }
    }
}