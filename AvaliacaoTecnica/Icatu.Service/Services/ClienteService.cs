using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;

namespace Icatu.Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepository repository) 
            : base(repository)
        {
        }
    }
}
