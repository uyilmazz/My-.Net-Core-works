using Business.Abstract;
using Business.Constants.Message;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandService : IBrandService
    {
        IBrandDal _brandDal;

        public BrandService(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _brandDal.Add(brand);
                return new SuccessResult(MessageText.SuccessMessage);
            }   
           
        }

        public IResult Delete(Brand brand)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _brandDal.Delete(brand);
                return new SuccessResult(MessageText.SuccessMessage);
            }
            
        }

        public IDataResult<Brand> Get(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Brand>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id), MessageText.SuccessMessage);
            }      
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), MessageText.SuccessMessage);
            }
         
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _brandDal.Update(brand);
                return new SuccessResult( MessageText.SuccessMessage);
            }
  
        }
    }
}
