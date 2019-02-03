using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tymish.Core.Entities;

namespace Tymish.Core.Interfaces
{
    public interface IRepository
    {
        T Get<T>(int id) where T : BaseEntity;
        IQueryable<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Delete<T>(int id) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
    }
}