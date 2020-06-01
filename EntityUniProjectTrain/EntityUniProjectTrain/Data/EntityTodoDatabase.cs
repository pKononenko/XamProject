using Microsoft.EntityFrameworkCore;

namespace EntityUniProjectTrain
{
    // Створення контексту данних для взаємодії
    // З базою даниз SQLite
    public class EntityTodoDatabase : DbContext
    {
        // DB path
        private string _databasePath;
        
        //public DbSet<Friend> Friends { get; set; }
        public DbSet<Notation> Notations { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<NotationMark> NotationsMarks { get; set; }

        public EntityTodoDatabase(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotationMark>()
                .HasKey(e => new { e.NotationId, e.MarkId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
