using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfExamsController : ControllerBase
    {
        ITypeOfExamService _typeOfExamService;
        public TypeOfExamsController(ITypeOfExamService typeOfExamService)
        {
            _typeOfExamService = typeOfExamService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _typeOfExamService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _typeOfExamService.getById(Id);
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
            var result = _typeOfExamService.getByName(name);
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
        public IActionResult Add(TypeOfExam typeOfExam)
        {
            var result = _typeOfExamService.add(typeOfExam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TypeOfExam typeOfExam)
        {
            var result = _typeOfExamService.update(typeOfExam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TypeOfExam typeOfExam)
        {
            var result = _typeOfExamService.delete(typeOfExam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
