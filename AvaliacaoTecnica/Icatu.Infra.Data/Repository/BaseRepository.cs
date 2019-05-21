using System.Collections.Generic;
using Icatu.Domain.Entities;
using Icatu.Domain.Interfaces;
using Microsoft.Extensions.Configuration;


namespace Icatu.Infra.Data.Repository
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
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("IcatuConnection").Value;
            return connection;
        }

        public abstract int Insert(T entity);

        public abstract int Update(T entity);
    }
}
