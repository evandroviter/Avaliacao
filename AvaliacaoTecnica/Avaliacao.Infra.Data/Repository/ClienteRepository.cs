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
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) 
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
                    var query = "DELETE FROM Clientes WHERE Id = @Id";                     
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

        public override Cliente Get(int id)
        {
            var connectionString = GetConnection();
            var cliente = new Cliente();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT * FROM Clientes WHERE Id = @Id";
                    cliente = conn.Query<Cliente>(query, new { Id = id }).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return cliente;
            }
        }

        public override IEnumerable<Cliente> GetAll()
        {
            var connectionString = GetConnection();
            var clientes = new List<Cliente>();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "SELECT * FROM Clientes";
                    clientes = conn.Query<Cliente>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return clientes;
            }
        }

        public override int Insert(Cliente entity)
        {
            var connectionString = GetConnection();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = "INSERT INTO Clientes (Nome, Cpf, Idade) Values (@Nome, @Cpf, @Idade)";
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

        public override int Update(Cliente entity)
        {
            var connectionString = GetConnection();
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var query = @"UPDATE Clientes SET 
                                  Nome = @Nome, 
                                  Cpf = @Cpf, 
                                  Idade = @Idade 
                                  WHERE Id = @Id";
                    return conn.Execute(query, new { entity.Nome, entity.Cpf, entity.Idade, entity.Id });
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
