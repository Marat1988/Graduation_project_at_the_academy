using Store.Models;
using System;

namespace Store.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool Processed { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}