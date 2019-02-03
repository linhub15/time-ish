using System;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;
using Tymish.Core.Shared;

namespace Tymish.Core.UseCases
{
    public interface IAddEmployee : IExecutable<Employee, AddEmployeeResponse> {}
    public class AddEmployeeResponse : BaseUseCaseResponse<Employee> {}
    
    public class AddEmployee : BaseUseCase, IAddEmployee
    {
        public AddEmployee(IRepository repository)
            : base(repository) {}

        public AddEmployeeResponse Execute(Employee employee)
        {
            AddEmployeeResponse response = new AddEmployeeResponse();
            try 
            {
                response.Data = _repository.Add<Employee>(employee);
                response.MarkSuccessful();
            }
            catch (Exception e) 
            {
                response.AddError(e.Message);
            }
            finally
            {
                // Log Execution
            }
            return response;
        }
    }
}