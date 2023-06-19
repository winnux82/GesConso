using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GesConso.Entities
{
    public class Article
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

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Column("DeletedAt")]
        public DateTime? DeletedAt { get; set; }

    }

}
