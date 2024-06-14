using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Upskilling.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display Order hanya dari 1 sampai 100")]
        public int DisplayOrder { get; set; }
    }
}
