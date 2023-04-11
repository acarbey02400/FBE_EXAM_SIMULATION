using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public IResult add(Student student)
        {
            _studentDal.Add(student);
            return new SuccessResult();
        }

        public IResult delete(Student student)
        {
            student.isDeleted = true;
            return new SuccessResult();
        }

        public IDataResult<List<Student>> getAll()
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll());
        }

        public IDataResult<List<Student>> getByClassromId(int ClassromId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.ClassromId==ClassromId));
        }

        public IDataResult<List<Student>> getByDepartmentId(int departmentId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.DepartmentId==departmentId));
        }

        public IDataResult<List<Student>> getByFacultyId(int facultyId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.FacultyId==facultyId));
        }

        public IDataResult<Student> getById(int id)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(p=>p.Id==id));
        }

        public IDataResult<List<Student>> getByName(string name)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.Name==name));
        }

        public IDataResult<Student> getByNumber(string number)
        {
            return new SuccessDataResult<Student>(_studentDal.Get(p=>p.Number==number));
        }

        public IDataResult<List<Student>> getByOrderId(int OrderId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.OrderId == OrderId));
        }

        public IDataResult<List<Student>> getBySemesterId(int SemesterId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.SemesterId==SemesterId));
        }

        public IDataResult<List<Student>> getBySurname(string surname)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.Surname==surname));
        }

        public IDataResult<List<Student>> getByTeachTypeId(int TeachTypeId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.TeachTypeId==TeachTypeId));
        }

        public IDataResult<List<Student>> getByYearId(int yearId)
        {
            return new SuccessDataResult<List<Student>>(_studentDal.GetAll(p=>p.YearId==yearId));
        }

        public IResult update(Student student)
        {
            _studentDal.Update(student);
            return new SuccessResult();
        }
    }
}
