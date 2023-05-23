using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelsController : ControllerBase
    {
        private readonly IExcelService _fileService;
        public ExcelsController(IExcelService fileService) 
        {
            _fileService = fileService;
        }
        [HttpPost("uploadExcel")]
        public IActionResult UploadExcel([FromForm]UploadExcelFile fromFile)
        {
           
            var result = _fileService.UploadFile(fromFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addlessonsfromexcel")]
        public IActionResult AddLessonFromExcel(Lesson lesson)
        {

            var result = _fileService.AddLesson(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addstudentsfromexcel")]
        public IActionResult AddStudentsFromExcel(Student student)
        {

            var result = _fileService.AddStudent(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addteachingoftype")]
        public IActionResult AddTeachingOfType()
        {

            var result = _fileService.AddTeachingOfType();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("adddepartment")]
        public IActionResult AddDepartment()
        {

            var result = _fileService.AddDepartment();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deletefiles")]
        public IActionResult DeleteFiles()
        {

            var result = _fileService.DeleteFiles();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
