using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class LessonBusinuessRules
    {
        private readonly IExamService _examService;
        private readonly IFacultiyService _facultiyService;
        private readonly IDepartmentService _departmentService;

        public LessonBusinuessRules(IExamService examService, IFacultiyService facultiyService, IDepartmentService departmentService)
        {
            _examService = examService;
            _facultiyService = facultiyService;
            _departmentService = departmentService;
        }


        public List<int> GetDepartmentId(int examId)
        {
           var dataExam= _examService.getById(examId);
            if (dataExam.Success) 
            { 
                var dataFacultiy=_facultiyService.getById(dataExam.Data.FacultiyId);
                if (dataFacultiy.Success) 
                {
                  var departments=  _departmentService.getByFacultiyId(dataFacultiy.Data.Id).Data.Select(x=>x.Id).ToList();
                    return departments;
                }

            }
            return new List<int>();
        }
    }
}
