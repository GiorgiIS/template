using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Core.Entities;
using ProjectTemplate.Repository.Interfaces;
using ProjectTemplate.Services.Dtos;
using ProjectTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTemplate.Common.Api
{
    [ApiController]

    public abstract class CrudController<TEntity, Dto, SearchQuery, ICrudService> : ControllerBase
        where TEntity : EntityBase
        where Dto : IDtoBase<TEntity>
        where SearchQuery : BaseSearchQuery
        where ICrudService : ICrudService<TEntity>
    {
        protected readonly ICrudService _crudService;
        private readonly IMapper _mapper;
        protected CrudController(ICrudService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        [HttpPost]
        public virtual string Create([Required][FromBody] Dto dto)
        {
            var entity = dto.Projection();
            var id = _crudService.Create(entity);
            var count = _crudService.SaveChanges();

            return id;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Dto Get([FromRoute]string id)
        {
            var entity = _crudService.Get(c => c.Id == id).FirstOrDefault();
            var dto = _mapper.Map<TEntity, Dto>(entity);

            return dto;
        }

        [HttpGet]
        public virtual IEnumerable<Dto> GetList([FromQuery]SearchQuery query)
        {
            var allData = _crudService.GetAll();
            var filtered = SearchHelper.Filter(allData, query);
            var dtoList = filtered.Select(f => _mapper.Map<TEntity, Dto>(f));

            return dtoList;
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual void Delete([FromRoute]string id)
        {
            _crudService.Delete(id);
            var count = _crudService.SaveChanges();
        }

        [HttpPut]
        public virtual void Update([FromBody]Dto dto)
        {
            var entity = dto.Projection();
            _crudService.Update(entity);
            var count = _crudService.SaveChanges();
        }
    }
}