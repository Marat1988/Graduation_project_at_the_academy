using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.ViewModel
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Index("UQ_GroupName", IsUnique = true)]
        [Required]
        [Display(Name = "Наименование группы")]
        public string Name { get; set; }
    }
}