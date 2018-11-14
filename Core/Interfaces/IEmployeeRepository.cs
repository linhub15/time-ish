using System.Collections.Generic;
using System.Threading.Tasks;

using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Get(int id);
        IEnumerable<Employee> List();

        int Add(Employee employee);
        Employee Update(Employee employee);
        void Delete(Employee employee);
    }
}