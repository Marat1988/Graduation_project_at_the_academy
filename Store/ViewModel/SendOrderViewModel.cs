
using System.ComponentModel.DataAnnotations;

namespace Store.ViewModel
{
    public class SendOrderViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        [RegularExpression(@"^((\+\d{1}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{2}[\s.-]\d{2})|((\+\d{3}\s)?\(?\d{2}\)?[\s.-]\d{3}[\s.-]\d{2}[\s.-]\d{2})$", ErrorMessage = "Неверный формат номера телефона")]
        public string telephone { get; set; }
    }
}