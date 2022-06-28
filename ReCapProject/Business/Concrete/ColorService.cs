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

            var result = _colorDal.Get(c => c.Name == color.Name);
            if(result is not null)
            {
                return new ErrorResult(color.Name + " " + MessageText.AlreadyExists);
            }
                _colorDal.Add(color);
                return new SuccessResult(MessageText.SuccessMessage);
            
        }

        public IResult Delete(Color color)
        {
            
                _colorDal.Delete(color);
                return new SuccessResult(MessageText.SuccessMessage);
            
        }

        public IDataResult<Color> Get(int id)
        {
            
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id) ,MessageText.SuccessMessage);
            
        }

        public IDataResult<List<Color>> GetAll()
        {
            
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll() ,MessageText.SuccessMessage);
            
        }

        public IResult Update(Color color)
        {
            var result = _colorDal.Get(c => c.Name == color.Name);
            if(result is not null)
            {
                return new ErrorResult(color.Name + " " + MessageText.AlreadyExists);
            }
            _colorDal.Update(color);
             return new SuccessResult(MessageText.SuccessMessage);
            
        }
    }
}
