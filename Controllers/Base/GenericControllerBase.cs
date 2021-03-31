using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos.Base;
using WebApplication3.Entities.Base;
using WebApplication3.Repositories;
using WebApplication3.Services;

namespace WebApplication3.Controllers.Base
{
    public class GenericControllerBase<TDto, TEntity> : ControllerBase where TDto : DtoObject where TEntity : Entity
    {
        private readonly GenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;
      

        public GenericControllerBase( GenericRepository<TEntity> repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;

        }


        [HttpGet]
        public async virtual Task<List<TDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<TDto>>(entities);
        }


        [HttpGet("{id}")]
        public virtual TDto GetById(int id)
        {
            var entity = _repository.FindById(id);
            return _mapper.Map<TDto>(entity);
        }


        [HttpPost]
        public async virtual Task Upsert(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.Upsert(entity);
        }



        [HttpDelete("{id}")]
        public async virtual Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}

