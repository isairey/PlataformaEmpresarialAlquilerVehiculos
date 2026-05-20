using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Nombre)
            .HasMaxLength(200)
            .HasConversion(nombre => nombre!.Value, value => new Nombre(value));

        builder.Property(user => user.Apellido)
            .HasMaxLength(200)
            .HasConversion(apellido => apellido!.Value, value => new Apellido(value));

        builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));

        builder.HasIndex(user => user.Email).IsUnique();
    }
}