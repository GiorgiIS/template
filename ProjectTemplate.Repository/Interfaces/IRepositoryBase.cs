﻿using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProjectTemplate.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        string Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(string id);
        int SaveChanges();
    }
}
