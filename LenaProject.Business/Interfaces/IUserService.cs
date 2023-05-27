using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LenaProject.Business.Interfaces
{
    public interface IUserService : IService<UserRegisterDto, UserUpdateDto, UserListDto, User>
    {
        Task<IResponse<UserRegisterDto>> CreateUserAsync(UserRegisterDto dto);
        Task<IResponse<UserListDto>> CheckUserAsync(UserLoginDto dto);
        Task<IResponse<List<UserLoginDto>>> GeyByLoginUserId(int id);



    }
}
