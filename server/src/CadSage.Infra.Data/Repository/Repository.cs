using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CadSage.Domain.Core.Models;
using CadSage.Domain.Interfaces;
using CadSage.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadSage.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected CadSageContext Db;
        protected DbSet<TEntity> DbSet;
        
        protected Repository(CadSageContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            obj.InformarUsuarioCriacao(DateTime.Now);
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity objNew)
        {
            var eventoAtual = ObterPorId(objNew.Id);

            objNew.InformarUsuarioCriacao(eventoAtual.DataCriacao);
            
            DbSet.Update(objNew);
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id && t.DataInativacao == null);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.Where(x => x.DataInativacao == null).ToList();
        }

        public virtual void Remover(TEntity obj)
        {
            obj.InformarInativacao();

            DbSet.Update(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}