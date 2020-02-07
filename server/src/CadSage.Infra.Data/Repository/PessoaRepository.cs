using CadSage.Domain.Entidades;
using CadSage.Domain.Interfaces.Repository;
using CadSage.Infra.Data.Context;

namespace CadSage.Infra.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(CadSageContext context)
            : base(context)
        {

        }
    }
}
