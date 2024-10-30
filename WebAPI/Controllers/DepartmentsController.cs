using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _departmentService.getAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfacultiyid")]
        public IActionResult GetByFacultiyId(int? facultiyId)
        {

            var result = _departmentService.getByFacultiyId(facultiyId);
                
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            
            
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _departmentService.getById(Id);
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
            var result = _departmentService.getByName(name);
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
        public IActionResult Add(Department department)
        {
            var result = _departmentService.add(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Department department)
        {
            var result = _departmentService.update(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Department department)
        {
            var result = _departmentService.delete(department);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
