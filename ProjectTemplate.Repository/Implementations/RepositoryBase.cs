using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.EF;
using ProjectTemplate.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjectTemplate.Repository.Implementations
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly CustomDbContext _context;

        public RepositoryBase(CustomDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(c => c.DeletedAt == null).AsNoTracking();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(c => c.DeletedAt == null).Where(expression).AsNoTracking();
        }

        public string Create(T entity)
        {
            var res =_context.Set<T>().Add(entity);
            return res.Entity.Id;
        }

        public string Update(T entity)
        {
            var res = _context.Set<T>().Update(entity);
            return res.Entity.Id;
        }

        public string Delete(T entity)
        {
            var res =_context.Set<T>().Remove(entity);
            return res.Entity.Id;
        }
    }
}
