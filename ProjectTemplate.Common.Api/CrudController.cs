using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTemplate.Common.Api
{
    [ApiController]

    public abstract class CrudController<TEntity, Dto, SearchQuery, Repository> : ControllerBase
        where TEntity : EntityBase
        where Dto : IDtoBase<TEntity>
        where SearchQuery: BaseSearchQuery
        where Repository : IRepositoryBase<TEntity>
    {
        protected readonly Repository _repository;
        private readonly IMapper _mapper;
        public CrudController(Repository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public virtual string Create([Required][FromBody] Dto dto)
        {
            var entity = dto.Projection();
            var id = _repository.Create(entity);
            var count = _repository.SaveChanges();

            return id;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Dto Get([FromRoute]string id)
        {
            var entity= _repository.Get(c => c.Id == id).FirstOrDefault();
            var dto = _mapper.Map<TEntity, Dto>(entity);

            return dto;
        }

        [HttpGet]
        public virtual IEnumerable<Dto> GetList([FromQuery]SearchQuery query)
        {
            var allData = _repository.GetAll();
            var filtered = SearchHelper.Filter(allData, query);
            var dtoList = filtered.Select(f => _mapper.Map<TEntity, Dto>(f));

            return dtoList;
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual void Delete([FromRoute]string id)
        {
            _repository.Delete(id);
            var count = _repository.SaveChanges();
        }

        [HttpPut]
        public virtual void Update([FromBody]Dto dto)
        {
            var entity = dto.Projection();
            _repository.Update(entity);
            var count = _repository.SaveChanges();
        }
    }
}