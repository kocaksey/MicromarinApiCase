using CommonLayer.ResponseObjects;
using DTOsLayer.Abstract;
using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<CreateDto,UpdateDto,ListDto,T>
        where CreateDto :  IDto, new()
        where UpdateDto :  IDto, new()
        where ListDto :  IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<List<ListDto>>> GetAll();

        Task<IResponse<CreateDto>> Create(CreateDto dto);

        Task<IResponse<IDto>> GetById<IDto>(int id);

        Task<IResponse> Remove(int id);

        Task<IResponse<UpdateDto>> Update(UpdateDto dto);
    }
}
