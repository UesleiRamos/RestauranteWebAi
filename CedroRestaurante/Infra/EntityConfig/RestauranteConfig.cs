using CedroRestaurante.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CedroRestaurante.Infra.EntityConfig
{
    public class RestauranteConfig : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("tbRestaurante");
            builder.HasKey(p => p.Id).HasName("PKRestaurante");
            builder.Property(p => p.Id).HasColumnName("IdRestaurante").ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();
        }
    }
}
