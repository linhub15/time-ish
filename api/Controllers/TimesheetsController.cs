using System.Collections.Generic;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly TimeishContext _context;
        public TimesheetsController(TimeishContext context)
        {
            _context = context;
        }

        // GET api/timesheets
        [HttpGet]
        public ActionResult<IEnumerable<Timesheet>> Get()
        {
            return _context.Timesheets
                .Include(t => t.PayPeriod)
                .ToList();
        }
        
        // GET api/timesheets/5
        [HttpGet("{id}")]
        public ActionResult<Timesheet> Get(int id)
        {
            return _context.Timesheets
                .Include(t => t.PayPeriod)
                .SingleOrDefault(t => t.Id == id);
                
        }

         // POST api/timesheets
        [HttpPost]
        public void Post([FromBody] Timesheet timesheet)
        {
            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();
        }

        // PUT api/timesheets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Timesheet timesheet)
        {
            timesheet.Id = id; //URL ID overrides PUT request Body
            _context.Timesheets.Update(timesheet);
            _context.SaveChanges();
        }

        // DELETE api/timesheets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var timesheet = _context.Timesheets
                .SingleOrDefault(t => t.Id == id);
            _context.Timesheets.Remove(timesheet);
            _context.SaveChanges();
        }
    } 
}