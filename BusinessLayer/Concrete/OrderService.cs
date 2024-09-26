using AutoMapper;
using BusinessLayer.Abstract;
using CommonLayer.ResponseObjects;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.OrderDtos;
using EntityLayer.Models.Concrete;
using FluentValidation;

namespace BusinessLayer.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRespository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<OrderCreateDto> _createDtoValidator;
        private readonly IValidator<OrderUpdateDto> _updateDtoValidator;

        public OrderService(IOrderRespository orderRepository, IMapper mapper, IUow uow, IValidator<OrderCreateDto> createDtoValidator, IValidator<OrderUpdateDto> updateDtoValidator)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<OrderCreateDto>> Create(OrderCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);

            if (validationResult.IsValid)
            {
                await _orderRepository.Create(_mapper.Map<Order>(dto));
                await _uow.SaveChanges();
                return new Response<OrderCreateDto>(ResponseType.Success, dto);
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

                return new Response<OrderCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<OrderListDto>>> GetAll()
        {
            var data = _mapper.Map<List<OrderListDto>>(await _orderRepository.GetAll());
            return new Response<List<OrderListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _orderRepository.GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }


        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _orderRepository.GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _orderRepository.Remove(removedEntity);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<OrderUpdateDto>> Update(OrderUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _orderRepository.GetById(dto.Id);
                if (updatedEntity != null)
                {
                    _orderRepository.Update(_mapper.Map<Order>(dto), updatedEntity);
                    await _uow.SaveChanges();
                    return new Response<OrderUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<OrderUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
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

                return new Response<OrderUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }
    }
}
