using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.CategoryDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CategoryCreateDto> _createDtoValidator;
        private readonly IValidator<CategoryUpdateDto> _updateDtoValidator;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUow uow, IValidator<CategoryCreateDto> createDtoValidator, IValidator<CategoryUpdateDto> updateDtoValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CategoryCreateDto>> Create(CategoryCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _categoryRepository.Create(_mapper.Map<Category>(dto));
                await _uow.SaveChanges();
                return new Response<CategoryCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new Response<CategoryCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<CategoryListDto>>> GetAll()
        {
            var data = _mapper.Map<List<CategoryListDto>>(await _categoryRepository.GetAll());
            return new Response<List<CategoryListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _categoryRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _categoryRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _categoryRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<CategoryUpdateDto>> Update(CategoryUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _categoryRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _categoryRepository.Update(_mapper.Map<Category>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<CategoryUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<CategoryUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in result.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }

                return new Response<CategoryUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
