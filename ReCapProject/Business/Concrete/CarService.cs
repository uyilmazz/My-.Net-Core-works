using Business.Abstract;
using Business.Constants.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        ICarDal _carDal;

        public CarService(ICarDal carDal)
        {

            _carDal = carDal;
        }

       
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            
                _carDal.Delete(car);
                return new SuccessResult(MessageText.SuccessMessage);
            
        }

        public IDataResult<Car> Get(int id)
        {
            
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), MessageText.SuccessMessage);
            
        }

        [CacheAspect()]
        public IDataResult<List<Car>> GetAll()
        {
            
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), MessageText.SuccessMessage);
            
        }

        public IDataResult<CarDetailDto> GetCarDetailDtoByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailDtoByCarId(carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(), MessageText.SuccessMessage);
            
   
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtosByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtosByBrandId(brandId), MessageText.SuccessMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtosByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtosByColorId(colorId), MessageText.SuccessMessage);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), MessageText.SuccessMessage);
            
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == colorId), MessageText.SuccessMessage);
            
        }

        public IDataResult<List<CarDetailDto>> GetFilteredCars(int? colorId, int? brandId)
        {
            if(colorId == null && brandId == null)
            {
                return GetCarDetailDtos();
            }
            else if(colorId == null && brandId != null)
            {
                return GetCarDetailDtosByBrandId((int)brandId);
            }
            else if(brandId == null && colorId != null)
            {
                return GetCarDetailDtosByColorId((int)colorId);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetFilteredCarDetailDtos((int)colorId, (int)brandId), MessageText.SuccessMessage);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            var result = _carDal.Get(c => c.Name.ToLower() == car.Name.ToLower());
            if(result is not null)
            {
                return new ErrorResult( car.Name + " "+ MessageText.AlreadyExists);
            }
            _carDal.Update(car);
            return new SuccessResult(MessageText.SuccessMessage);
            
        }
    }
}
