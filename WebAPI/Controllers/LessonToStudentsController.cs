using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonToStudentsController : ControllerBase
    {
        IlessonToStudentService _lessonToStudentService;
        public LessonToStudentsController(IlessonToStudentService lessonToStudentService)
        {
            _lessonToStudentService = lessonToStudentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _lessonToStudentService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _lessonToStudentService.getById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbylessonid")]
        public IActionResult GetByLessonId(int Id)
        {
            var result = _lessonToStudentService.getByLessonId(Id);
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
            var result = _lessonToStudentService.getByStudentId(Id);
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
        public IActionResult Add(LessonToStudent lessonToStudent)
        {
            var result = _lessonToStudentService.add(lessonToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(LessonToStudent lessonToStudent)
        {
            var result = _lessonToStudentService.update(lessonToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(LessonToStudent lessonToStudent)
        {
            var result = _lessonToStudentService.delete(lessonToStudent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
