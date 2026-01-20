using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantBooking.Domain.Entities;

namespace RestaurantBooking.Infrastructure.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("reservations");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnName("id");

        builder.Property(r => r.Code)
            .HasColumnName("code")
            .IsRequired();

        builder.Property(r => r.ReservationDate)
            .HasColumnName("reservation_date")
            .IsRequired();

        builder.Property(r => r.NumberOfGuests)
            .HasColumnName("number_of_guests")
            .IsRequired();

        builder.Property(r => r.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired();

        builder.HasIndex(r => r.Code).IsUnique();
    }
}
