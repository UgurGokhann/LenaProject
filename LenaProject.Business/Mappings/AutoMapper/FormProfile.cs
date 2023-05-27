using AutoMapper;
using LenaProject.DataAccess.Entities;

namespace LenaProject.Business.Mappings.AutoMapper
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormListDto>().ReverseMap();
            CreateMap<Form, FormCreateDto>().ReverseMap();

        }
    }
}
