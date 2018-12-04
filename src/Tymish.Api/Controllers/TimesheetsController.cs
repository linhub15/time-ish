using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Tymish.Core.Entities;
using Tymish.Core.UseCases;
using Tymish.Infrastructure.DataAccess;

namespace Tymish.Api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly TimeishContext _context;
        private readonly IListTimeSheets _listTimeSheets;
        private readonly IGetTimeSheet _getTimeSheet;
        private readonly IAddTimeSheet _addTimesheet;
        private readonly IUpdateTimeSheet _updateTimeSheet;
        private readonly IDeleteTimeSheet _deleteTimeSheet;

        public TimeSheetsController(
            TimeishContext context, 
            IListTimeSheets listTimeSheets,
            IGetTimeSheet getTimeSheet,
            IAddTimeSheet addTimeSheet,
            IUpdateTimeSheet updateTimeSheet,
            IDeleteTimeSheet deleteTimeSheet)
        
        {
            _context = context;
            _listTimeSheets = listTimeSheets;
            _getTimeSheet = getTimeSheet;
            _addTimesheet = addTimeSheet;
            _updateTimeSheet = updateTimeSheet;
            _deleteTimeSheet = deleteTimeSheet;
        }

        // GET api/TimeSheets
        [HttpGet]
        public ActionResult<IEnumerable<TimeSheet>> Get()
        {
            return _listTimeSheets.Execute(null).ToList();
        }
        
        // GET api/TimeSheets/5
        [HttpGet("{id}")]
        public ActionResult<TimeSheet> Get(int id)
        {
            return _getTimeSheet.Execute(id);
        }

         // POST api/TimeSheets
        [HttpPost]
        public ActionResult<TimeSheet> Post([FromBody] TimeSheet timeSheet)
        {
            TryValidateModel(timeSheet);
            _addTimesheet.Execute(timeSheet);
            return _getTimeSheet.Execute(timeSheet.Id);
        }

        // PUT api/TimeSheets/5
        [HttpPut("{id}")]
        public ActionResult<TimeSheet> Put(int id, [FromBody] TimeSheet timeSheet)
        {
            timeSheet.Id = id; //URL ID overrides PUT request Body
            TryValidateModel(timeSheet);
            _updateTimeSheet.Execute(timeSheet);
            return _getTimeSheet.Execute(timeSheet.Id);
        }

        // DELETE api/TimeSheets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _deleteTimeSheet.Execute(id);
        }

        [HttpDelete("activities/{id}")]
        public void DeleteActivity(int id)
        {
            var activity = _context.Activities
                .SingleOrDefault(a => a.Id == id);
            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }
    }
}