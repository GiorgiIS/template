using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjectTemplate.Application
{
    public abstract class CrudService<T> : ICrudService<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository;
        protected CrudService(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual string Create(T entity)
        {
            var resp = _repository.Create(entity);
            return resp;
        }
        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }
        public virtual void Delete(string id)
        {
            _repository.Delete(id);
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            var resp = _repository.Get(expression);
            return resp;
        }
        public virtual IQueryable<T> GetAll()
        {
            var resp = _repository.GetAll();
            return resp;
        }
        public virtual int SaveChanges()
        {
            var resp = _repository.SaveChanges();
            return resp;
        }
        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
