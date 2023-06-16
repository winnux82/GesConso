using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GesConso.Entities
{
    public class ArticleDTO
    {
        [Key]
        [Column("Id_Article")]
        public Guid? Id { get; set; }

        [Column("Denomination")]
        public string? Denomination {get; set;}

        [Column("Description")]
        public string? Description { get; set; }

        [Column("PuHtva")]
        public double? PuHtva { get; set; }

   }

}
