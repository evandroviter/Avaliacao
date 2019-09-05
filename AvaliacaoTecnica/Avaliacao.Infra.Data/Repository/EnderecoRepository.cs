using Dapper;
using Avaliacao.Domain.Entities;
using Avaliacao.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Avaliacao.Infra.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration) 
            : base(configuration)
        {
        }
        public override int Delete(int id)
        {
            var connectionString = GetConnection();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "DELETE FROM Enderecos WHERE Id = @Id";
                    return conn.Execute(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override Endereco Get(int id)
        {
            var connectionString = GetConnection();
            var Endereco = new Endereco();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT * FROM Enderecos WHERE Id = @Id";
                    Endereco = conn.Query<Endereco>(query, new { Id = id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return Endereco;
            }
        }

        public override IEnumerable<Endereco> GetAll()
        {
            var connectionString = GetConnection();
            var Enderecos = new List<Endereco>();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT * FROM Enderecos";
                    Enderecos = conn.Query<Endereco>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return Enderecos;
            }
        }

        public override int Insert(Endereco entity)
        {
            var connectionString = GetConnection();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = @"INSERT INTO Enderecos (ClienteId, Logradouro, Bairro, Cidade, Estado) 
                                  Values (@ClienteId, @Logradouro, @Bairro, @Cidade, @Estado)";
                    return conn.Execute(query, entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public override int Update(Endereco entity)
        {
            var connectionString = GetConnection();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = @"UPDATE Enderecos SET 
                                  ClienteId = @ClienteId, 
                                  Logradouro = @Logradouro, 
                                  Bairro = @Bairro,
                                  Cidade = @Cidade,
                                  Estado = @Estado
                                  WHERE Id = @Id";
                    return conn.Execute(query, new { entity.ClienteId, entity.Logradouro, entity.Bairro, entity.Cidade, entity.Estado, entity.Id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
