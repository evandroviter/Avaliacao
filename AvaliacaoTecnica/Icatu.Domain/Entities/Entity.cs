using Icatu.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Icatu.Domain.Entities
{
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
