using System.Collections.Generic;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetsController : ControllerBase
    {
        private readonly TimeishContext _context;
        public TimeSheetsController(TimeishContext context)
        {
            _context = context;
        }

        // GET api/TimeSheets
        [HttpGet]
        public ActionResult<IEnumerable<TimeSheet>> Get()
        {
            return _context.TimeSheets
                .Include(t => t.PayPeriod)
                .Include(t => t.Activities)
                .ToList();
        }
        
        // GET api/TimeSheets/5
        [HttpGet("{id}")]
        public ActionResult<TimeSheet> Get(int id)
        {
            return _context.TimeSheets
                .Include(t => t.PayPeriod)
                .Include(t => t.Activities)
                .SingleOrDefault(t => t.Id == id);
                
        }

         // POST api/TimeSheets
        [HttpPost]
        public void Post([FromBody] TimeSheet TimeSheet)
        {
            _context.TimeSheets.Add(TimeSheet);
            _context.SaveChanges();
        }

        // PUT api/TimeSheets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TimeSheet TimeSheet)
        {
            TimeSheet.Id = id; //URL ID overrides PUT request Body
            _context.TimeSheets.Update(TimeSheet);
            _context.SaveChanges();
        }

        // DELETE api/TimeSheets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var TimeSheet = _context.TimeSheets
                .SingleOrDefault(t => t.Id == id);
            _context.TimeSheets.Remove(TimeSheet);
            _context.SaveChanges();
        }
    } 
}