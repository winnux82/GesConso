using Microsoft.EntityFrameworkCore;
using GesConso.Entities;
namespace Stage {
    public class Database : DbContext {
        public DbSet<ArticleDTO> Articles { get; set; } = null!;
        public Database(DbContextOptions options) : base(options) {

        }
    }
}