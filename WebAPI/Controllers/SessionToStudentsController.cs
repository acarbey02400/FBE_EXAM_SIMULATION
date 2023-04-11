using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionToStudentsController : ControllerBase
    {
        ISessionToStudentService _sessionToStudentService;
        public SessionToStudentsController(ISessionToStudentService sessionToStudentService)
        {
            _sessionToStudentService = sessionToStudentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _sessionToStudentService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _sessionToStudentService.getById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbysessionid")]
        public IActionResult GetBySessionId(int Id)
        {
            var result = _sessionToStudentService.getBySessionId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbystudentid")]
        public IActionResult GetByStudentId(int Id)
        {
            var result = _sessionToStudentService.getByStudentId(Id);
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
        public IActionResult Add(SessionToStudent sessionToStudent)
        {
            var result = _sessionToStudentService.add(sessionToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SessionToStudent sessionToStudent)
        {
            var result = _sessionToStudentService.update(sessionToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SessionToStudent sessionToStudent)
        {
            var result = _sessionToStudentService.delete(sessionToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
