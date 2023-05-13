using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        public IResult add(Student student);
        public IResult update(Student student);
        public IResult delete(Student student);
        public IDataResult<List<Student>> getAll();
        public IDataResult<List<Student>> getByName(string name);
        public IDataResult<List<Student>> getBySurname(string surname);
        public IDataResult<Student> getById(int id);
        public IDataResult<Student> getByNumber(string number);
        public IDataResult<List<Student>> getByDepartmentId(int departmentId);
        public IDataResult<List<Student>> getByFacultyId(int facultyId);
        public IDataResult<List<Student>> getBySemesterId(int SemesterId);
        public IDataResult<List<Student>> getByYearId(int yearId);
        public IDataResult<List<Student>> getByTeachTypeId(int TeachTypeId);
        public IDataResult<List<Student>> getByClassromId(int ClassromId);
        public IDataResult<List<Student>> getByOrderId(int OrderId);
        public IDataResult<List<Student>> getByExamId(int ExamId);
        public IDataResult<List<StudentDetailDto>> getStudentDetails();
    }
}
