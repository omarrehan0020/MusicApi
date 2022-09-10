
using System.Data.Entity;

namespace MusicApi.Models
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        
        
    }
}
