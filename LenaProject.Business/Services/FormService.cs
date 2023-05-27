using AutoMapper;
using FluentValidation;
using LenaProject.Business.Interfaces;
using LenaProject.DataAccess.Entities;
using LenaProject.DataAccess.Response;
using LenaProject.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenaProject.Business.Services
{
    public class FormService : Service<FormCreateDto, FormUpdateDto, FormListDto, Form>, IFormService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public FormService(IMapper mapper, IValidator<FormCreateDto> createDtoValidator, IValidator<FormUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;

        }

        public async Task<List<FormListDto>> GetAllFormsWithFields()
        {
            var query = _uow.GetRepository<Form>().GetQuery();
            var forms = await query.Include(x=>x.Fields).Include(x=>x.User).ToListAsync();
            
            return _mapper.Map<List<FormListDto>>(forms);
        }
        public async Task<FormListDto> GetFormByIdWithFields(int id)
        {
            var query = _uow.GetRepository<Form>().GetQuery();
            var forms = await query.Include(x => x.Fields).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<FormListDto>(forms);
        }

        public async Task<List<FormListDto>> GetByForm(string searchString)
        {
            var modifiedString = searchString.ToLower().Trim();
            var query = _uow.GetRepository<Form>().GetQuery();
            var forms = await query.Include(x => x.Fields).Include(x => x.User).Where(x => x.Name.Contains(modifiedString) || x.Description.Contains(modifiedString) || x.User.Username.Contains(modifiedString) || x.Fields.Any(y=>y.Name.Contains(modifiedString))).ToListAsync();
            return _mapper.Map<List<FormListDto>>(forms);
        }

    }
}
