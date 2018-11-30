using System;
using Tymish.Core.Entities;
using Tymish.Core.Interfaces;

namespace Tymish.Core.UseCases
{
    public interface IApproveTimeSheet : IExecutable<TimeSheet, bool> {}

    public class ApproveTimeSheet : BaseUseCase, IApproveTimeSheet
    {
        public ApproveTimeSheet(IRepository repository)
            : base(repository) {}
        
        public bool Execute(TimeSheet timeSheet)
        {
            timeSheet.Approved = DateTime.Now;
            _repository.Update(timeSheet);
            return true;
        }
    }
}