﻿using Business.Abstract;
using Business.Constants.Message;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalService : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalService(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if(result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(MessageText.SuccessMessage);
            }
  
            else
            {
                return new ErrorResult(MessageText.ReturnRentalError);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(MessageText.SuccessMessage);
        }

        public IDataResult<List<RentalDto>> GetAllRentalDtos()
        {
            var result = _rentalDal.GetAllRentalDtos();
            if(result is not null)
            {
                return new SuccessDataResult<List<RentalDto>>(result,MessageText.SuccessMessage);
            }
            return new ErrorDataResult<List<RentalDto>>(result, MessageText.ErrorMessage);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<bool> isRentable(int id)
        {
            Rental rentalDto = _rentalDal.Get(r => r.Id == id && r.ReturnDate == null);
            if (rentalDto is not null)
            {
                return new SuccessDataResult<bool>(false);
            }
            return new SuccessDataResult<bool>(true);
        }

       

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(MessageText.SuccessMessage);
        }
    }
}
