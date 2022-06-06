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
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccessResult(MessageText.SuccessMessage);
            }
        }

        public IDataResult<Car> Get(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Car>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), MessageText.SuccessMessage);
            }
        }

        [CacheAspect()]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), MessageText.SuccessMessage);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos(), MessageText.SuccessMessage);
            }
   
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), MessageText.SuccessMessage);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == colorId), MessageText.SuccessMessage);
            }
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(MessageText.SuccessMessage);
            }
        }
    }
}
