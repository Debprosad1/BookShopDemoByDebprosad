using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookShop.Models
{
    public class CBook
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Available")]

        public bool IsAvailable { get; set; }

        [Display(Name = "Book Type")]
        [Required]
        public int BookTypeId { get; set; }
        [ForeignKey("BookTypeId")]
        public virtual CBookTypes BookTypes { get; set; }

    }
}
