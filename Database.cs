using Microsoft.EntityFrameworkCore;
using GesConso.Entities;
namespace GesConso {
    public class Database : DbContext {
        public DbSet<Article> Articles { get; set; } = null!;

        public DbSet<Commande> Commandes { get; set; } = null!;

        public DbSet<CommandeArticle> CommandeArticle { get; set; } = null!;

        public Database(DbContextOptions options) : base(options) {

        }
    }
}