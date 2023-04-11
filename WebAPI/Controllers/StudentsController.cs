using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _studentService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _studentService.getById(Id);
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
            var result = _studentService.getByDepartmentId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyfacultiyid")]
        public IActionResult GetByFacultiyId(int Id)
        {
            var result = _studentService.getByFacultyId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyclassromid")]
        public IActionResult GetByClassromId(int Id)
        {
            var result = _studentService.getByClassromId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyorderid")]
        public IActionResult GetByOrderId(int Id)
        {
            var result = _studentService.getByOrderId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyyearid")]
        public IActionResult GetByYearId(int Id)
        {
            var result = _studentService.getByYearId(Id);
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
            var result = _studentService.getBySemesterId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyteachtypeid")]
        public IActionResult GetByTeachTypeId(int Id)
        {
            var result = _studentService.getByTeachTypeId(Id);
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
            var result = _studentService.getByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbysurname")]
        public IActionResult GetBySurname(string surname)
        {
            var result = _studentService.getBySurname(surname);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbynumber")]
        public IActionResult GetByNumber(string number)
        {
            var result = _studentService.getByNumber(number);
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
        public IActionResult Add(Student student)
        {
            var result = _studentService.add(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Student student)
        {
            var result = _studentService.update(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Student student)
        {
            var result = _studentService.delete(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
