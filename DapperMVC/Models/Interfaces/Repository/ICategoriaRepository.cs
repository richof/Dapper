using System;
using System.Collections;
using System.Collections.Generic;
using Entidades.Entities;

namespace DapperMVC.Models.Interfaces.Repository
{
    public interface ICategoriaRepository
    {
        void Adicionar(Categoria categoria);
        IEnumerable<Categoria> GetTodos();
        Categoria GetPorId(Guid id);
        void Remover(Guid id);
        void Editar(Categoria categoria);

    }
}