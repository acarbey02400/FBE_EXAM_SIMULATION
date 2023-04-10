using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassromsController : ControllerBase
    {
        IClassromService _classromService;
        public ClassromsController(IClassromService classromService)
        {
            _classromService = classromService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _classromService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _classromService.getById(Id);
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
        public IActionResult Add(Classrom classrom)
        {
            var result = _classromService.add(classrom);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
