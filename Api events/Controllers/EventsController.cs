using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IDataContext _context;
        private int id = 3;
        public EventsController(IDataContext context)
        {
           _context = context;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.EventList);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eve= _context.EventList.Find(x=>x.Id==id);
            if (eve is null)
                return NotFound();
            return Ok(eve);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            _context.EventList.Add(new Event() { Id=id++,Title=newEvent.Title,Start=newEvent.Start,End=newEvent.End});
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            var eve = _context.EventList.Find(x => x.Id == id);
            eve.Title = newEvent.Title;
            eve.Start = newEvent.Start;
            eve.End = newEvent.End;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = _context.EventList.Find(e => e.Id == id);
            _context.EventList.Remove(eve);
        }
    }
}
