using FluentValidation;
using LenaProject.Business.Interfaces;
using LenaProject.Business.Services;
using LenaProject.Business.ValidationRules.FormValidation;
using LenaProject.Business.ValidationRules.UserValidation;
using LenaProject.DataAccess.Context;
using LenaProject.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LenaProject.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUow, Uow>();
           

            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserLoginDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

            services.AddTransient<IValidator<FormCreateDto>, FormCreateDtoValidator>();
            services.AddTransient<IValidator<FormUpdateDto>, FormUpdateDtoValidator>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFormService, FormService>();



        }
    }
}
