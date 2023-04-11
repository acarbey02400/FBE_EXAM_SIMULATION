using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingOfTypesController : ControllerBase
    {

        ITeachingOfTypeService _teachingOfTypeService;
        public TeachingOfTypesController(ITeachingOfTypeService teachingOfTypeService)
        {
            _teachingOfTypeService = teachingOfTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _teachingOfTypeService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _teachingOfTypeService.getById(Id);
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
            var result = _teachingOfTypeService.getByName(name);
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
        public IActionResult Add(TeachingOfType teachingOfType)
        {
            var result = _teachingOfTypeService.add(teachingOfType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TeachingOfType teachingOfType)
        {
            var result = _teachingOfTypeService.update(teachingOfType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TeachingOfType teachingOfType)
        {
            var result = _teachingOfTypeService.delete(teachingOfType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
