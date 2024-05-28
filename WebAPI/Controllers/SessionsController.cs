using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        ISessionService _sessionService;
        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _sessionService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getsessiondetails")]
        public IActionResult GetSessionDetails()
        {

            var result = _sessionService.getSessionDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _sessionService.getById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyexamid")]
        public IActionResult GetByExamId(int Id)
        {
            var result = _sessionService.getByExamId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbydatetime")]
        public IActionResult GetByDateTime(DateTime dateTime)
        {
            var result = _sessionService.getByDateTime(dateTime);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Session session)
        {
            var result = _sessionService.add(session);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Session session)
        {
            var result = _sessionService.update(session);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Session session)
        {
            var result = _sessionService.delete(session);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("checkSessionTime")]
        public IActionResult CheckSessionTime([FromBody] List<Lesson> lessons) 
        {
            var result = _sessionService.CheckSessionTime(lessons);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
