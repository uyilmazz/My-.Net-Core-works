using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDtos();
        List<CarDetailDto> GetCarDetailDtosByBrandId(int brandId);
        CarDetailDto GetCarDetailDtoByCarId(int carId);
    }
}
