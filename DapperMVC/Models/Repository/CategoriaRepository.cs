using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperMVC.Models.Interfaces.Repository;
using Entidades.Entities;

namespace DapperMVC.Models.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoriaRepository()
        {
          _dbConnection =new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            
        }
        public void Adicionar(Categoria categoria)
        {
            var sql = "INSERT INTO Categoria" +
                      "(CategoriaID,Nome) VALUES(@CategoriaId,@Nome);";
            _dbConnection.Query(sql, categoria);        
        }

        public IEnumerable<Categoria> GetTodos()
        {
            var sql = "SELECT * FROM Categoria;";
            var categorias=_dbConnection.Query<Categoria>(sql);
            return categorias;
        }

        public Categoria GetPorId(Guid id)
        {
            var sql = "SELECT * FROM Categoria " +
                      "WHERE CategoriaId = @sid";
            var categoria = _dbConnection.Query<Categoria>(sql,new{sid= id}).FirstOrDefault();
            return categoria;
        }

        public void Remover(Guid id)
        {
            var sql = "DELETE FROM Categoria " +
                      "WHERE CategoriaId = @sid";
            _dbConnection.Query<Categoria>(sql, new {sid = id});
        }

        public void Editar(Categoria categoria)
        {
            var sql = "UPDATE Categoria " +
                      "SET Nome=@Nome " +
                      "WHERE CategoriaId=@CategoriaId";
            _dbConnection.Query<Categoria>(sql, categoria);
        }
    }
}