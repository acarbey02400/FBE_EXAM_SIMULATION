using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExcelService
    {
        public Core.Utilities.Results.IResult UploadFile(UploadExcelFile file);
        public Core.Utilities.Results.IResult AddLesson(Lesson lesson);
        public Core.Utilities.Results.IResult AddStudent(Student student);
        public Core.Utilities.Results.IResult AddDepartment(int facultiyId);
        public Core.Utilities.Results.IResult AddTeachingOfType();
        public Core.Utilities.Results.IResult DeleteFiles();
    }
}
