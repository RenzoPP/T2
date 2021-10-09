using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalidadT2.Models.Maps
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.UsuarioId);
        }
    }
}
