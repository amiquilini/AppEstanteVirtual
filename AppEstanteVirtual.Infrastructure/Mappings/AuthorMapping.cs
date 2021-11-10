using AppEstanteVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEstanteVirtual.Infrastructure.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(key => new { key.Id });

            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Name)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasMany(prop => prop.Books)
                .WithOne(prop => prop.Author);

            builder.Navigation(prop => prop.Books)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
