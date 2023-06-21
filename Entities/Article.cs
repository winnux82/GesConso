using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class Article
    {
        [Key]
        [Column("Id_Article")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Le champ dénomination est requis.")]
        [MinLength(2, ErrorMessage = "Le champ dénomination doit avoir au moins 2 caractères.")]
        //[RegularExpression("\\d+", ErrorMessage = "doit être décimal")]
        [Column("Denomination")]
        public string? Denomination {get; set;}

        [Column("Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le champ PuHtva est requis.")]
        [Range(0, double.MaxValue, ErrorMessage = "Le champ PuHtva doit être un chiffre positif.")]
        [Column("PuHtva")]
        public double? PuHtva { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; }

    }

}
