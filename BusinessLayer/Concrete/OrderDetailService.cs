using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.OrderDetailDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.Concrete
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<OrderDetailCreateDto> _createDtoValidator;
        private readonly IValidator<OrderDetailUpdateDto> _updateDtoValidator;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper, IUow uow, IValidator<OrderDetailCreateDto> createDtoValidator, IValidator<OrderDetailUpdateDto> updateDtoValidator)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<OrderDetailCreateDto>> Create(OrderDetailCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _orderDetailRepository.Create(_mapper.Map<OrderDetail>(dto));
                await _uow.SaveChanges();
                return new Response<OrderDetailCreateDto>(ResponseType.Success, dto);
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

                return new Response<OrderDetailCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<OrderDetailListDto>>> GetAll()
        {
            var data = _mapper.Map<List<OrderDetailListDto>>(await _orderDetailRepository.GetAll());
            return new Response<List<OrderDetailListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _orderDetailRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _orderDetailRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _orderDetailRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<OrderDetailUpdateDto>> Update(OrderDetailUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _orderDetailRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _orderDetailRepository.Update(_mapper.Map<OrderDetail>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<OrderDetailUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<OrderDetailUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
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

                return new Response<OrderDetailUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
