using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAir.Areas.Identity.Data;
using TravelAir.Models;

namespace TravelAir.Data;

public class TravelAirDbContext : IdentityDbContext<ApplicationUser>
{
    public TravelAirDbContext(DbContextOptions<TravelAirDbContext> options)
        : base(options)
    {
    }


    public DbSet<FlightOffer> FlightOffers { get; set; }

    public DbSet<AppUserFlightOffer> AppUserFlightOffers { get; set; }

    public DbSet<CabinClass> CabinClasses { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Airport> Airports { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Country> Countries { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<AppUserFlightOffer>()
        .HasKey(aufo => new { aufo.AppUserId, aufo.FlightOfferId });

        builder.Entity<AppUserFlightOffer>()
            .HasOne(aufo => aufo.AppUser)
            .WithMany(au => au.AppUserFlightOffers)
            .HasForeignKey(aufo => aufo.AppUserId);

        builder.Entity<AppUserFlightOffer>()
            .HasOne(aufo => aufo.FlightOffer)
            .WithMany(fo => fo.AppUserFlightOffers)
            .HasForeignKey(aufo => aufo.FlightOfferId);
    }
}
