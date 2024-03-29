﻿using ProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.Services.Dtos
{
    public abstract class UpdateDtoBase<TEntity> where TEntity : EntityBase
    {
        public string Id { get; set; }
    }
}
