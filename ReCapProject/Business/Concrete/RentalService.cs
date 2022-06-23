using Business.Abstract;
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
        ICrediCardService _crediCardService;
        IPaymentService _paymentService;
        ICarService _carService;

        public RentalService(IRentalDal rentalDal, ICrediCardService crediCardService, IPaymentService paymentService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _crediCardService = crediCardService;
            _paymentService = paymentService;
            _carService = carService;
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

        public IResult Rent(RentPaymentRequest rentPaymentRequest)
        {
            var result = _crediCardService.GetCrediCardDtoByCrediCard(rentPaymentRequest.CrediCard);
            if (result.Success)
            {
                if(result.Data.Balance > rentPaymentRequest.Amount)
                {
                    _crediCardService.DraftMoney(result.Data.Id,rentPaymentRequest.Amount);
                    
                    foreach(var rental in rentPaymentRequest.Rentals)
                    {
                        var periodDay = Convert.ToInt32(((DateTime)rental.ReturnDate - rental.RentDate).TotalDays);
                        var currentCar = _carService.Get(rental.CarId).Data;
                        if(currentCar is null)
                            return new ErrorResult(MessageText.ErrorDuringRental);
                        
                        var amount = periodDay * currentCar.DailyPrice;
                        _paymentService.Add(new Payment {CarId = rental.CarId,RentDate = rental.RentDate,ReturnDate = (DateTime)rental.ReturnDate,
                            CardId = result.Data.Id,CustomerId = rentPaymentRequest.CustomerId,
                            Amount = amount});
                        rental.ReturnDate = null;
                        _rentalDal.Add(rental);
                    }

                    return new SuccessResult(MessageText.PaymentSuccessfull);

                }
                return new ErrorResult(MessageText.InsufficientBalance);
            }
            return new ErrorResult(MessageText.CrediCardNotFound);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(MessageText.SuccessMessage);
        }
    }
}
