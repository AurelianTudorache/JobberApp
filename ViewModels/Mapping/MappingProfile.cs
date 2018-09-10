using AutoMapper;
using JobberApp.Data.Models;
using JobberApp.Data.Models.Employee;
using JobberApp.ViewModels;

namespace JobberApp.ViewModels.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //AddNewPage
            CreateMap<Employer, EmployerViewModel>();

            CreateMap<Location, LocationViewModel>();
            CreateMap<Location, SaveLocationModel>();
            CreateMap<SaveLocationModel, Location>();
            
            CreateMap<Skill, SkillViewModel>();      
             
            CreateMap<Employee, EmployeeViewModel>();   
            CreateMap<Employer, SaveEmployerModel>();
            CreateMap<SaveEmployerModel, Employer>();

            CreateMap<ApplicationUser, ApplicationUserViewModel>();

            CreateMap<Card, CardViewModel>();
            CreateMap<Card, SaveCardModel>();
            CreateMap<SaveCardModel, Card>();

            CreateMap<JobAd, JobAdViewModel>();
            CreateMap<JobAd, SaveJobAdModel>();
            CreateMap<SaveJobAdModel, JobAd>();
        }
    }
}