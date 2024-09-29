using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set;}   
        [Required]
        public decimal ProductPrice { get; set; }
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string? ThumbNailImage { get; set; }
    }
}
