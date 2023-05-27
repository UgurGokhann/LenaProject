using AutoMapper;
using FluentValidation;
using LenaProject.Business.Extensions;
using LenaProject.Business.Interfaces;
using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Response;
using LenaProject.DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LenaProject.Business.Services
{
    public class UserService : Service<UserRegisterDto, UserUpdateDto, UserListDto, User>, IUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRegisterDto> _createDtoValidator;
        private readonly IValidator<UserLoginDto> _loginDtoValidator;
        public UserService(IMapper mapper, IValidator<UserRegisterDto> createDtoValidator, IValidator<UserUpdateDto> updateDtoValidator, IUow uow, IValidator<UserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<IResponse<UserRegisterDto>> CreateUserAsync(UserRegisterDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<User>(dto);

                await _uow.GetRepository<User>().CreateAsync(user);

                await _uow.SaveChangesAsync();
                return new Response<UserRegisterDto>(ResponseType.Success, dto);

            }
            return new Response<UserRegisterDto>(dto, validationResult.ConvertToCustomValidationError());
        }
        public async Task<IResponse<UserListDto>> CheckUserAsync(UserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<User>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<UserListDto>(user);
                    return new Response<UserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<UserListDto>(ResponseType.NotFound, "Username or password is wrong!");
            }
            return new Response<UserListDto>(ResponseType.ValidationError, "Username or password cannot be empty!");
        }

        public async Task<IResponse<List<UserLoginDto>>> GeyByLoginUserId(int id)
        {
            var query = await _uow.GetRepository<User>().FindAsync(id);

            var dto = _mapper.Map<List<UserLoginDto>>(query);

            return new Response<List<UserLoginDto>>(ResponseType.Success, dto);
        }
    }
}
