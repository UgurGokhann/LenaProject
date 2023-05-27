using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>

        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();

    }
}
