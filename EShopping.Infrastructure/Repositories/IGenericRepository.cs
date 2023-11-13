﻿using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntitiesQuery();

        Task<TEntity?> GetEntityById(int entityId);

        Task AddEntity(TEntity entity);
        void UpdateEntity(TEntity? entity);
        void RemoveEntity(TEntity? entity);

        Task RemoveEntity(int entityId);

        Task SaveChanges();
    }
}
