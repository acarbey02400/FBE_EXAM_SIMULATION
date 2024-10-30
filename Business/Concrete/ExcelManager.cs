using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class ExcelManager : IExcelService
    {
        ILessonService _lessonService;
        IStudentService _studentService;
        IDepartmentService _departmentService;
        ITeachingOfTypeService _teachingOfTypeService;
        IlessonToStudentService _lessonToStudentService;
        public ExcelManager(ILessonService service,IStudentService studentService, IDepartmentService departmentService, ITeachingOfTypeService teachingOfTypeService, IlessonToStudentService lessonToStudentService)
        {
            _lessonService = service;
            _studentService = studentService;
            _departmentService = departmentService;
            _teachingOfTypeService = teachingOfTypeService;
            _lessonToStudentService = lessonToStudentService;

        }
        private DataSet dataSet;

        public Core.Utilities.Results.IResult UploadFile(UploadExcelFile file)
        {
            if(file.formFile == null) { return new ErrorResult("lütfen dosya seçiniz."); }

            if (file.formFile.FileName.ToLower().EndsWith(".xlsx"))
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.formFile.FileName);
                string path = Path.Combine("UploadFile", uniqueFileName);
                using (FileStream stream = new FileStream(path, FileMode.CreateNew))
                {
                    file.formFile.CopyTo(stream);
                }
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fileStream);
                dataSet = reader.AsDataSet(
                    new ExcelDataSetConfiguration()
                    {
                     UseColumnDataType=false,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                fileStream.Close();
                
                return new SuccessResult();
          
            }
            return new ErrorResult();
        }
        public Core.Utilities.Results.IResult AddStudent(Student student)
        {
           var departments= _departmentService.getAll();
            var teachingOfTypes=_teachingOfTypeService.getAll();
            List<string> studentNumber = new List<string>();
            var data = _studentService.getAll();
            foreach (var item in data.Data)
            {
                studentNumber.Add(item.Number);
            }
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                bool studentCheck = true;
                foreach (var item in studentNumber)
                {
                    if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString() == item)
                    {
                        studentCheck = false;
                    }
                }
                if (studentCheck)
                {
                    Student student1 = new Student();
                    student1.SemesterId=student.SemesterId;
                    student1.isDeleted = false;
                    student1.OrderId = student.OrderId;
                    student1.YearId= student.YearId;
                    student1.ExamId= student.ExamId;
                    student1.Name = dataSet.Tables[0].Rows[i].ItemArray[2].ToString();
                    student1.Surname= dataSet.Tables[0].Rows[i].ItemArray[3].ToString();
                    student1.Number = dataSet.Tables[0].Rows[i].ItemArray[1].ToString();
                    student1.DepartmentId = departments.Data.Where(p=>p.Name==dataSet.Tables[0].Rows[i].ItemArray[0].ToString()).FirstOrDefault().Id;
                    student1.TeachTypeId = teachingOfTypes.Data.Where(p => p.Name==dataSet.Tables[0].Rows[i].ItemArray[4].ToString()).FirstOrDefault().Id;
                    _studentService.add(student1);
                    _lessonToStudentService.add(new()
                    {
                        StudentId =student1.Id,
                        LessonId = _lessonService.getByLessonCode(dataSet.Tables[0].Rows[i].ItemArray[10].ToString()).Data.Id,
                    });
                    studentNumber.Add(student1.Number);
                }
            }
                return new SuccessResult();
        }
        public Core.Utilities.Results.IResult AddLesson(Lesson lesson)
        {
            List<string> lessonCode = new List<string>();
           var data= _lessonService.getAll();
            foreach (var item in data.Data)
            {
                lessonCode.Add(item.LessonCode);
            }
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                bool lessonCheck=true;
                foreach (var item in lessonCode)
                {
                    if (dataSet.Tables[0].Rows[i].ItemArray[10].ToString()==item)
                    {
                        lessonCheck = false;
                    }  
                }
                if (lessonCheck)
                {
                    Lesson lesson1 = new Lesson();
                    lesson1.isDeleted = false;
                    lesson1.LessonCode = dataSet.Tables[0].Rows[i].ItemArray[10].ToString();
                    lesson1.Name = dataSet.Tables[0].Rows[i].ItemArray[11].ToString();
                   lesson1.SessionId=lesson.SessionId;
                    lesson1.SemesterId=lesson.SemesterId;
                    lesson1.DepartmentId=_departmentService.getByName(dataSet.Tables[0].Rows[i].ItemArray[0].ToString()).Data.FirstOrDefault().Id;
                    lesson1.ExamId = lesson.ExamId;
                    lesson1.YearId=lesson.YearId;
                    lesson1.LessonTime=lesson.LessonTime;
                    _lessonService.add(lesson1);
                   
                    lessonCode.Add(lesson1.LessonCode);
                }
                
            }
            return new SuccessResult();
        }
        public Core.Utilities.Results.IResult AddDepartment(int facultiyId)
        {
            List<string> departmentName = new List<string>();
            var data = _departmentService.getAll();
            foreach (var item in data.Data)
            {
                departmentName.Add(item.Name);
            }
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                bool departmentCheck = true;
                foreach (var item in departmentName)
                {
                    if (dataSet.Tables[0].Rows[i].ItemArray[0].ToString() == item)
                    {
                        departmentCheck = false;
                    }
                }
                if (departmentCheck)
                {
                    Department department = new Department() { isDeleted = false, Name = dataSet.Tables[0].Rows[i].ItemArray[0].ToString(),FacultiyId=facultiyId };
                    _departmentService.add(department);
                    departmentName.Add(department.Name);
                }

            }
            return new SuccessResult();
        }
        public Core.Utilities.Results.IResult AddTeachingOfType()
        {
            List<string> teachingOfTypeName = new List<string>();
           var data= _teachingOfTypeService.getAll();
            foreach (var item in data.Data)
            {
                teachingOfTypeName.Add(item.Name);
            }
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                bool departmentCheck = true;
                foreach (var item in teachingOfTypeName)
                {
                    if (dataSet.Tables[0].Rows[i].ItemArray[4].ToString() == item)
                    {
                        departmentCheck = false;
                    }
                }
                if (departmentCheck)
                {
                    TeachingOfType teachingOfType = new TeachingOfType() { isDeleted = false, Name = dataSet.Tables[0].Rows[i].ItemArray[4].ToString() };
                    _teachingOfTypeService.add(teachingOfType);
                    teachingOfTypeName.Add(teachingOfType.Name);
                }

            }
            return new SuccessResult();
        }

            public Core.Utilities.Results.IResult DeleteFiles()
            {
                string[] files = Directory.GetFiles("UploadFile/");
                foreach (string item in files)
                {
                    System.IO.File.Delete(item);
                }
            if (dataSet!=null)
            {
                dataSet.Clear();
                dataSet.Reset();
            }
                
                return new SuccessResult();
            }
}
}
