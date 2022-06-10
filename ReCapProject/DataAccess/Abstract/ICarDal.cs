using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDtos();
        List<CarDetailDto> GetCarDetailDtosByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailDtosByColorId(int colorID);
        CarDetailDto GetCarDetailDtoByCarId(int carId);
        List<CarDetailDto> GetFilteredCarDetailDtos(int colorId,int brandId);

    }
}
