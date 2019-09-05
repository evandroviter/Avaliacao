using Avaliacao.Domain.Entities;
using Avaliacao.Domain.Interfaces;

namespace Avaliacao.Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepository repository) 
            : base(repository)
        {
        }
    }
}
