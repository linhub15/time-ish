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
            var Timesheets = _context.Timesheets
                .Include(Timesheet => Timesheet.PayPeriod)
                .ToList();
            return Timesheets;
        }
        
        // GET api/timesheets/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"id: { id }";
        }

         // POST api/timesheets
        [HttpPost]
        public void Post([FromBody] string timesheet)
        {
        }

        // PUT api/timesheets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string timesheet)
        {
        }

        // DELETE api/timesheets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    } 
}