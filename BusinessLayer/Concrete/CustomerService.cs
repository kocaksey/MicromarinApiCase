using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.CustomerDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CustomerCreateDto> _createDtoValidator;
        private readonly IValidator<CustomerUpdateDto> _updateDtoValidator;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IUow uow, IValidator<CustomerCreateDto> createDtoValidator, IValidator<CustomerUpdateDto> updateDtoValidator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CustomerCreateDto>> Create(CustomerCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _customerRepository.Create(_mapper.Map<Customer>(dto));
                await _uow.SaveChanges();
                return new Response<CustomerCreateDto>(ResponseType.Success, dto);
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

                return new Response<CustomerCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<CustomerListDto>>> GetAll()
        {
            var data = _mapper.Map<List<CustomerListDto>>(await _customerRepository.GetAll());
            return new Response<List<CustomerListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _customerRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _customerRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _customerRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<CustomerUpdateDto>> Update(CustomerUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _customerRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _customerRepository.Update(_mapper.Map<Customer>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<CustomerUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<CustomerUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
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

                return new Response<CustomerUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
