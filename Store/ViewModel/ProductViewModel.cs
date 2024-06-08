using System.ComponentModel.DataAnnotations;

namespace Store.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Display(Name = "Наименование товара")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Цена товара")]
        public decimal Price { get; set; }
        [Display(Name = "Персональная цена")]
        public decimal PersonalPrice { get; set; }    
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public bool IsPicture { get; set; }
    }
}