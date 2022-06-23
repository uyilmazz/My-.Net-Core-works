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
    public class CrediCardService : ICrediCardService
    {
        ICrediCardDal _credicardDal;

        public CrediCardService(ICrediCardDal credicardDal)
        {
            _credicardDal = credicardDal;
        }

        public IDataResult<bool> AddMoney(int crediCardId, int money)
        {
            var crediCard = _credicardDal.Get(card => card.Id == crediCardId);
            if(crediCard is not null)
            {
                crediCard.Balance += money;
                _credicardDal.Update(crediCard);
                return new SuccessDataResult<bool>(true,MessageText.MoneyAddedSuccess);
            }
            return new ErrorDataResult<bool>(false, MessageText.CrediCardNotFound);
        }

 

        public IDataResult<bool> DraftMoney(int crediCardId, double money)
        {
            var crediCard = _credicardDal.Get(card => card.Id == crediCardId);
            if(crediCard is not null)
            {
                if(crediCard.Balance > money)
                {
                    crediCard.Balance -= money;
                    _credicardDal.Update(crediCard);
                    return new SuccessDataResult<bool>(true);
                }
                else
                {
                    return new ErrorDataResult<bool>(false, MessageText.InsufficientBalance);
                }
            }
            return new ErrorDataResult<bool>(false, MessageText.CrediCardNotFound);
        }

        public IDataResult<CrediCardDto> GetCrediCardDto(int id)
        {
            var crediCard = _credicardDal.Get(card => card.Id == id);

            if(crediCard is not null)
            {
                var newCrediCardDto = new CrediCardDto
                {
                    CardHolderFullName = crediCard.CardHolderFullName,
                    CardNumber = crediCard.CardNumber,
                    Balance = crediCard.Balance,
                    Cvc = crediCard.Cvc,
                    ExpireMonth = crediCard.ExpireMonth,
                    ExpireYear = crediCard.ExpireYear
                };
                return new SuccessDataResult<CrediCardDto>(newCrediCardDto);
            }
            return new ErrorDataResult<CrediCardDto>();
        }

        public IDataResult<CrediCard> GetCrediCardDtoByCrediCard(CrediCard crediCard)
        {
            var result = _credicardDal.Get(card => card.CardHolderFullName == crediCard.CardHolderFullName && card.CardNumber == crediCard.CardNumber
            && card.ExpireYear == crediCard.ExpireYear && card.ExpireMonth == crediCard.ExpireMonth && card.Cvc == crediCard.Cvc);
            
            if(result is not null)
            {
                return new SuccessDataResult<CrediCard>(result);
            }
            return new ErrorDataResult<CrediCard>();
            
        }

        public IDataResult<bool> Pay(CrediCardDto crediCardDto,int money)
        {
            var crediCard = _credicardDal.Get(card => card.CardNumber == crediCardDto.CardNumber && card.CardHolderFullName == crediCardDto.CardHolderFullName 
            && card.ExpireMonth == crediCardDto.ExpireMonth && card.ExpireYear == crediCardDto.ExpireYear && card.Cvc == crediCardDto.Cvc);
            if(crediCard is not null)
            {
                return DraftMoney(crediCard.Id, money);
            }
            return new ErrorDataResult<bool>(false,MessageText.CrediCardNotFound);
        }
    }
}
