using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectTemplate.Common.Api
{
    public abstract class CrudController<Dto, DbModel> : ControllerBase where DbModel : BaseEntity
    {
        protected readonly IRepositoryBase<DbModel> _repository;

        public CrudController(IRepositoryBase<DbModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public virtual Guid Create([Required][FromBody] Dto input)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public virtual Dto Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual IEnumerable<Dto> GetList()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public virtual void Delete(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public virtual void Update(Dto input)
        {
            throw new NotImplementedException();
        }
    }
}
