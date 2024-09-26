using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.EmployeeDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<EmployeeCreateDto> _createDtoValidator;
        private readonly IValidator<EmployeeUpdateDto> _updateDtoValidator;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUow uow, IValidator<EmployeeCreateDto> createDtoValidator, IValidator<EmployeeUpdateDto> updateDtoValidator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<EmployeeCreateDto>> Create(EmployeeCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _employeeRepository.Create(_mapper.Map<Employee>(dto));
                await _uow.SaveChanges();
                return new Response<EmployeeCreateDto>(ResponseType.Success, dto);
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

                return new Response<EmployeeCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<EmployeeListDto>>> GetAll()
        {
            var data = _mapper.Map<List<EmployeeListDto>>(await _employeeRepository.GetAll());
            return new Response<List<EmployeeListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _employeeRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _employeeRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _employeeRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<EmployeeUpdateDto>> Update(EmployeeUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _employeeRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _employeeRepository.Update(_mapper.Map<Employee>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<EmployeeUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<EmployeeUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
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

                return new Response<EmployeeUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
