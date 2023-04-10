using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClassromManager>().As<IClassromService>().SingleInstance();
            builder.RegisterType<DegreeManager>().As<IDegreeService>().SingleInstance();
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<ExamManager>().As<IExamService>().SingleInstance();
            //SingleInstance ben ekledim
            builder.RegisterType<FacultiyManager>().As<IFacultiyService>();
            builder.RegisterType<LessonManager>().As<ILessonService>();
            builder.RegisterType<LessonToStudentManager>().As<IlessonToStudentService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<SemesterManager>().As<ISemesterService>();
            builder.RegisterType<SessionManager>().As<ISessionService>();
            builder.RegisterType<SessionToStudentManager>().As<ISessionToStudentService>();
            builder.RegisterType<StaffManager>().As<IStaffService>();
            builder.RegisterType<StudentManager>().As<IStudentService>();
            builder.RegisterType<TeachingOfTypeManager>().As<ITeachingOfTypeService>();
            builder.RegisterType<YearManager>().As<IYearService>();


            //Dal
            builder.RegisterType<EfClassromDal>().As<IClassromDal>();
            builder.RegisterType<EfDegreeDal>().As<IDegreeDal>();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>();
            builder.RegisterType<EfExamDal>().As<IExamDal>();
            builder.RegisterType<EfFacultyDal>().As<IFacultyDal>();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>();
            builder.RegisterType<EfLessonToStudentDal>().As<ILessonToStudentDal>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfSemesterDal>().As<ISemesterDal>();
            builder.RegisterType<EfSessionDal>().As<ISessionDal>();
            builder.RegisterType<EfSessionToStudentDal>().As<ISessionToStudentDal>();
            builder.RegisterType<EfStaffDal>().As<IStaffDal>();
            builder.RegisterType<EfStudentDal>().As<IStudentDal>();
            builder.RegisterType<EfTeachingOfTypeDal>().As<ITeachingOfTypeDal>();
            builder.RegisterType<EfYearDal>().As<IYearDal>();
        


            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
