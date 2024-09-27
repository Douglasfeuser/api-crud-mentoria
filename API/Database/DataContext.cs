using ApiCrud.Database.Seeder;

namespace ApiCrud.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Rent> Rents => Set<Rent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<Client>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);

        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId)
            .HasPrincipalKey(g => g.Id);
        
        modelBuilder.Entity<Rent>()
            .HasKey(r => r.Id);
        
        modelBuilder.Entity<Rent>()
            .HasMany(r => r.Books)
            .WithMany(b => b.Rents)
            .UsingEntity(j => j.ToTable("RentBooks"));

        modelBuilder.Entity<Rent>()
            .HasOne(r => r.Client)
            .WithMany(c => c.Rents)
            .HasForeignKey(r => r.ClientId);
        
        modelBuilder.Entity<Rent>()
            .HasOne(r => r.Client)
            .WithMany(c => c.Rents)
            .HasForeignKey(r => r.ClientId);
    }
}
