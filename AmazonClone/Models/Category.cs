using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
