using CadSage.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadSage.Domain.Entidades;

namespace CadSage.Infra.Data.Mappings
{
    public class PessoaMapping : EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.CPF)
               .HasColumnType("varchar(11)")
               .IsRequired();

            builder.Property(e => e.Email)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.Rua)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(e => e.CEP)
               .HasColumnType("varchar(8)")
               .IsRequired();

            builder.Property(e => e.Bairro)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.Cidade)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.UF)
               .HasColumnType("varchar(2)")
               .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Pessoa");
        }
    }
}