using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


        // CarDetail Dto
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
        IDataResult<List<CarDetailDto>> GetCarDetailDtosByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailDtosByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetFilteredCars(int? colorId, int? brandId);
        IDataResult<CarDetailDto> GetCarDetailDtoByCarId(int carId);

        


    }
}
