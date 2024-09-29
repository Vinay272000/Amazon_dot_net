using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonClone.Models
{
    public class States
    {
        public int CountryId {get; set;}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StateId { get; set; }

        [Required]
        public string? StateName { get; set; }
    }
}
