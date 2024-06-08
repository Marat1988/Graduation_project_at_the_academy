using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Index(IsUnique = true)]
        [Required]
        [Display(Name = "Наименование поставщика")]
        public string Name { get; set; }
    }
}