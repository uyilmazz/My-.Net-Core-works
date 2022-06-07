﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDto> GetAllCustomerDtos()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDetailDtos = from c in context.Customers
                                    join u in context.Users on
                                    c.UserId equals u.Id
                                    select new CustomerDto
                                    {
                                        CompanyName = c.CompanyName,
                                        CustomerName = u.FirstName + " " + u.LastName,
                                        Id = c.Id,
                                                                                                
                                    };
                                    
                return carDetailDtos.ToList();
            }
        }
    }
}
