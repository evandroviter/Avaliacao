using Avaliacao.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Avaliacao.Domain.Entities
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
