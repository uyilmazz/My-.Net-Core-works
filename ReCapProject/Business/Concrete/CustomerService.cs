using Business.Abstract;
using Business.Constants.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class CustomerService : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(MessageText.SuccessMessage);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), MessageText.SuccessMessage);
        }

        public IDataResult<List<CustomerDto>> GetAllCustomerDto()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetAllCustomerDtos(), MessageText.SuccessMessage);
        }

        public IDataResult<CustomerUserDto> GetByEmail(string email)
        {
            var result = _customerDal.GetByEmail(email);
            if(result is null)
            {
                return new ErrorDataResult<CustomerUserDto>(MessageText.UserNotFound);
            }
            return new SuccessDataResult<CustomerUserDto>(result);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(MessageText.SuccessMessage);
        }
    }
}
