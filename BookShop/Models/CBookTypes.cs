using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class CBookTypes
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Book Types")]
        public string BookTypes { get; set; }
    }
}
