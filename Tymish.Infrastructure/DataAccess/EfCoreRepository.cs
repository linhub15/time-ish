using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Infrastructure.DataAccess
{
    public class EfCoreRepository : IRepository
    {
        private readonly TimeishContext _context;

        public EfCoreRepository(TimeishContext context)
        {
            _context = context;
        }

        public T Get<T>(int id) where T : BaseEntity
        {
            return _context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _context.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete<T>(int id) where T : BaseEntity
        {
            T entity = _context.Set<T>().SingleOrDefault(e => e.Id == id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}