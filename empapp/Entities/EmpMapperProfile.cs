using AutoMapper;
using empapp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace empapp.Entities
{
    public class EmpMapperProfile: Profile
    {
        public EmpMapperProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Salaries, AddSalary>().ReverseMap();
            CreateMap<LeaveOfAbsence, PostEmployeeLeave>().ReverseMap();
        }
    }

    public static class EmpMapperProfileExtensions
    {
        public static void AddMapperProfileConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmpMapperProfile>();
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
