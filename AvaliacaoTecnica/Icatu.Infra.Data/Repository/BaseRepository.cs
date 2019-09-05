using System.Collections.Generic;
using Avaliacao.Domain.Entities;
using Avaliacao.Domain.Interfaces;
using Microsoft.Extensions.Configuration;


namespace Avaliacao.Infra.Data.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract int Delete(int id);
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetAll();

        public virtual string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("AvaliacaoConnection").Value;
            return connection;
        }

        public abstract int Insert(T entity);

        public abstract int Update(T entity);
    }
}
