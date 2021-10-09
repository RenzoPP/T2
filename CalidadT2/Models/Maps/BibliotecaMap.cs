using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalidadT2.Models.Maps
{
    public class BibliotecaMap : IEntityTypeConfiguration<Biblioteca>
    {
        public void Configure(EntityTypeBuilder<Biblioteca> builder)
        {
            builder.ToTable("Biblioteca");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Libro)
                .WithMany()
                .HasForeignKey(o => o.LibroId);
        }
    }
}
