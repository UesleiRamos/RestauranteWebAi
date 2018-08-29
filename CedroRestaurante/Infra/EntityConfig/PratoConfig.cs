using CedroRestaurante.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CedroRestaurante.Infra.EntityConfig
{
    public class PratoConfig : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("tbPrato");
            builder.HasKey(w => w.Id).HasName("PKPrato");
            builder.Property(w => w.Id).HasColumnName("IdPrato").ValueGeneratedOnAdd();
            builder.Property(w => w.Descricao).HasColumnName("Descricao").HasMaxLength(255).IsRequired();
            builder.Property(w => w.RestauranteId).HasColumnName("IdRestaurante").IsRequired();

            builder.HasOne(w => w.Restaurante).WithMany(w => w.Pratos).HasForeignKey(w => w.RestauranteId).HasConstraintName("FKRESTAURANTEPRATO").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
