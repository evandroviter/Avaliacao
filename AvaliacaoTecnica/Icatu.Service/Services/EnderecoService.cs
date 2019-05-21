using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;

namespace Icatu.Service.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository) 
            : base(repository)
        {
        }
    }
}
