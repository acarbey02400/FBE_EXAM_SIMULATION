using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {

        IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _examService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyyearid")]
        public IActionResult GetByYearId(int id)
        {

            var result = _examService.getByYearId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbydepartmentid")]
        public IActionResult GetByDepartmentId(int id)
        {

            var result = _examService.getByDepartmentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfacultiyid")]
        public IActionResult GetByFacultyId(int id)
        {

            var result = _examService.getByFacultiyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbysemesterid")]
        public IActionResult GetBySemesterId(int id)
        {

            var result = _examService.getBySemesterId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _examService.getById(Id);
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
            var result = _examService.getByName(name);
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
        public IActionResult Add(Exam exam)
        {
            var result = _examService.add(exam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Exam exam)
        {
            var result = _examService.update(exam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Exam exam)
        {
            var result = _examService.delete(exam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
