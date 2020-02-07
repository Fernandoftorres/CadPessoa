using CadSage.Infra.Data.Extensions;
using CadSage.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CadSage.Infra.Data.Context
{
    public class CadSageContext : DbContext
    {
        public CadSageContext(DbContextOptions<CadSageContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PessoaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}