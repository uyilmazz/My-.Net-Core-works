using Business.Abstract;
using Business.Constants;
using Business.Constants.Message;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageService : ICarImageService
    {
        ICarImageDal _carImageDal;
        FileHeplerManager _fileHelperManager;

        public CarImageService(ICarImageDal carImageDal, FileHeplerManager fileHelperManager)
        {
            _carImageDal = carImageDal;
            _fileHelperManager = fileHelperManager;
        }

        public IResult Add(IFormFile file,int carId)
        {
            var result = BusinessRules.Run(CheckCarImageCountLimit(carId));
            if(result is not null)
            {
                return result;
            }
            var carImage = new CarImage();
            carImage.ImagePath = _fileHelperManager.Upload(file,ProjectConstant.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarId = carId;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);
            _fileHelperManager.Delete(ProjectConstant.ImagePath+carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            // Must refactor
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Count == 0) result.Add(new CarImage { ImagePath = ProjectConstant.ImagePath + ProjectConstant.DefaultImage });
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(IFormFile file,int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);
            _fileHelperManager.Update(file,ProjectConstant.ImagePath + carImage.ImagePath,ProjectConstant.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        
        private IResult CheckCarImageCountLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if(result >= 5)
            {
                return new ErrorResult(MessageText.CarImageCountLimitError);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckCarImagesEmpty(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);
            if(carImages.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(carImages);
            }
            carImages = new List<CarImage>();
            carImages.Add(new CarImage
                {
                    ImagePath = ProjectConstant.ImagePath + ProjectConstant.DefaultImage
                });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
