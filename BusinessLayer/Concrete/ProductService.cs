using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.ProductDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<ProductCreateDto> _createDtoValidator;
        private readonly IValidator<ProductUpdateDto> _updateDtoValidator;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUow uow, IValidator<ProductCreateDto> createDtoValidator, IValidator<ProductUpdateDto> updateDtoValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<ProductCreateDto>> Create(ProductCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _productRepository.Create(_mapper.Map<Product>(dto));
                await _uow.SaveChanges();
                return new Response<ProductCreateDto>(ResponseType.Success, dto);
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

                return new Response<ProductCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<ProductListDto>>> GetAll()
        {
            var data = _mapper.Map<List<ProductListDto>>(await _productRepository.GetAll());
            return new Response<List<ProductListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _productRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<List<ProductListDto>>> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetQuery()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
            var productDtos = _mapper.Map<List<ProductListDto>>(products);

            return new Response<List<ProductListDto>>(ResponseType.Success, productDtos);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _productRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _productRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<ProductUpdateDto>> Update(ProductUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _productRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _productRepository.Update(_mapper.Map<Product>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<ProductUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<ProductUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
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

                return new Response<ProductUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
