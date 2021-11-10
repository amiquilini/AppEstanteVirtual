using AppEstanteVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppEstanteVirtual.Domain.Enums;
using System;

namespace AppEstanteVirtual.Infrastructure.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(key => new { key.Id });

            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(prop => prop.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(prop => prop.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(prop => prop.AuthorId);

            builder.Property(prop => prop.AuthorId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.Pages)
                .HasColumnType("int");

            builder.Property(prop => prop.Genre)
                .HasConversion(
                    g => g.ToString(),
                    g => (GenreEnum)Enum.Parse(typeof(GenreEnum), g));

            builder.Property(prop => prop.Progress)
                .HasConversion(
                    p => p.ToString(),
                    p => (ProgressEnum)Enum.Parse(typeof(ProgressEnum), p));

            builder.Property(prop => prop.CoverUrl)
                .HasColumnType("varchar(100)");

        }
    }
}
