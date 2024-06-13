using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Upskilling_Razor.Model
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Category Name")]
		public string Name { get; set; }
		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order hanya dari 1 sampai 100")]
		public int DisplayOrder { get; set; }
	}
}
