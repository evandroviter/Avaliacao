using System.ComponentModel.DataAnnotations;

namespace Avaliacao.Domain.Entities
{
    public class Endereco : Entity<int>
    {
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string  Estado { get; set; }
    }
}
