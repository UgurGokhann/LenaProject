using AutoMapper;
using LenaProject.DataAccess.Entities;

namespace LenaProject.Business.Mappings.AutoMapper
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<Field,FieldListDto>().ReverseMap();
        }
    }
}
