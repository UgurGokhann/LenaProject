using LenaProject.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LenaProject.Business.Interfaces
{
    public interface IFormService : IService<FormCreateDto, FormUpdateDto, FormListDto, Form>
    {
        Task<List<FormListDto>> GetByForm(string searchString);
        Task<List<FormListDto>> GetAllFormsWithFields();
        Task<FormListDto> GetFormByIdWithFields(int id);
    }
}
