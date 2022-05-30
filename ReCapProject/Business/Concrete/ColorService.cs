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
    public class ColorService : IColorService
    {
        IColorDal _colorDal;

        public ColorService(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(MessageText.SuccessMessage);
            }
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _colorDal.Delete(color);
                return new SuccessResult(MessageText.SuccessMessage);
            }
        }

        public IDataResult<Color> Get(int id)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Color>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id) ,MessageText.SuccessMessage);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(MessageText.ErrorMessage);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll() ,MessageText.SuccessMessage);
            }
        }

        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(MessageText.ErrorMessage);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(MessageText.SuccessMessage);
            }
        }
    }
}
