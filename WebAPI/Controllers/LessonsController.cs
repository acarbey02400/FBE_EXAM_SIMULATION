using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {

        ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _lessonService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _lessonService.getById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyexamdatetime")]
        public IActionResult getByExamDateTime(DateTime dateTime)
        {
            var result = _lessonService.getByExamDateTime(dateTime);
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
            var result = _lessonService.getByExamId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbytypeexamid")]
        public IActionResult GetByTypeExamId(int Id)
        {
            var result = _lessonService.getByTypeExamId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbysemesterid")]
        public IActionResult GetBySemesterId(int Id)
        {
            var result = _lessonService.getBySemesterId(Id);
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
            var result = _lessonService.getBySessionId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbystaffid")]
        public IActionResult GetByStaffId(int Id)
        {
            var result = _lessonService.getByStaffId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbydepartmentid")]
        public IActionResult GetByDepartmentId(int Id)
        {
            var result = _lessonService.getByDepartmentId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("getbyname")]
        public IActionResult GetByname(string name)
        {
            var result = _lessonService.getByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbylessoncode")]
        public IActionResult GetByLessonCode(string code)
        {
            var result = _lessonService.getByLessonCode(code);
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
        public IActionResult Add(Lesson lesson)
        {
            var result = _lessonService.add(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Lesson lesson)
        {
            var result = _lessonService.update(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Lesson lesson)
        {
            var result = _lessonService.delete(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
