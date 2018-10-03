using System.Collections.Generic;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly TimeishDbContext _dbContext;
        public TimesheetsController(TimeishDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        // GET api/timesheets
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"1","2"};
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