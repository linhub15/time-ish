using System.Collections.Generic;
using System.Threading.Tasks;

using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface IRepository
    {
        T Get<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
    }
}