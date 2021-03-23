﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SilikatLab.lib.Interfaces;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Data.Base
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : Entity, new()
    {
        private readonly SPLaboratoryEntities _entities;
        private readonly DbSet<T> _table;
        protected SPLaboratoryEntities Context => _entities;
        public BaseRepository(SPLaboratoryEntities laboratoryEntities)
        {
            _entities = laboratoryEntities;
            _table = _entities.Set<T>();
        }
        internal int SaveChanges()
        {
            try
            {
                return _entities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Dispose() => _entities?.Dispose();
        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }
        public T GetOne(int Id) => _table.Find(Id);
        public IEnumerable<T> GetAll() => _table;
        public int Save(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Delete(int Id, byte[] Timestamp)
        {
            _entities.Entry(new T() {Id = Id, Timestamp = Timestamp}).State = EntityState.Deleted;
            return SaveChanges();
        }
    }
}
