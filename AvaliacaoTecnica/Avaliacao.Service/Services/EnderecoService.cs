using Avaliacao.Domain.Entities;
using Avaliacao.Domain.Interfaces;

namespace Avaliacao.Service.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository) 
            : base(repository)
        {
        }
    }
}
