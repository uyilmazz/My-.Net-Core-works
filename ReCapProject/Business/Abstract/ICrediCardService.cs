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
    public interface ICrediCardService
    {
        IDataResult<CrediCardDto> GetCrediCardDto(int id);
        IDataResult<CrediCard> GetCrediCardDtoByCrediCard(CrediCard crediCard);
        IDataResult<bool> AddMoney(int crediCardId,int money);
        IDataResult<bool> DraftMoney(int crediCardId,double money);
        IDataResult<bool> Pay(CrediCardDto crediCardDto, int money);
    }
}
