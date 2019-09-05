
namespace Avaliacao.Domain.Entities
{
    public class Cliente : Entity<int>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
    }
}
