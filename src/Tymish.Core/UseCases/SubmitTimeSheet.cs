using System;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface ISubmitTimeSheet : IExecutable<TimeSheet, bool> {}

    public class SubmitTimesheet : BaseUseCase, ISubmitTimeSheet
    {
        public SubmitTimesheet(IRepository repository)
            : base(repository) {}
        
        public bool Execute(TimeSheet timeSheet)
        {
            timeSheet.Submitted = DateTime.Now;
            _repository.Update(timeSheet);
            return true;
        }
    }
}