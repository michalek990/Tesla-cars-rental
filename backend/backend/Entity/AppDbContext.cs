using Microsoft.EntityFrameworkCore;

namespace backend.Entity;

public class AppDbContext : DbContext
{
        private string dbConnection = "Server=DESKTOP-T2TJMGJ;Database=TeslaCarsRental;Trusted_Connection=True;Trust Server Certificate=true";
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalPoint> RentalPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>()
            .HasOne(x => x.StartRentalPoint)
            .WithOne(x => x.StartRental)
            .HasForeignKey<Rental>(x => x.StartRentalPointId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Rental>()
            .HasOne(x => x.EndRentalPoint)
            .WithOne(x => x.EndRental)
            .HasForeignKey<Rental>(x => x.EndRentalPointId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Car>()
            .Property(a => a.VIN)
            .IsRequired()
            .HasMaxLength(17);
        
        modelBuilder.Entity<RentalPoint>()
            .Property(a => a.Number)
            .IsRequired()
            .HasMaxLength(4);
        
        modelBuilder.Entity<Rental>()
            .Property(a => a.PeselNumber)
            .IsRequired()
            .HasMaxLength(11);
        
        modelBuilder.Entity<Rental>()
            .Property(a => a.ContactNumber)
            .IsRequired()
            .HasMaxLength(9);

        modelBuilder.Entity<Rental>()
            .Property(a => a.Nationality)
            .IsRequired()
            .HasConversion<string>();

        modelBuilder.Entity<Rental>()
            .Property(a => a.Gender)
            .IsRequired()
            .HasConversion<string>();


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(dbConnection);
    }
}