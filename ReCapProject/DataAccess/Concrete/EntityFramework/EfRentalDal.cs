using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> GetAllRentalDtos()
        {
           using(ReCapContext context = new ReCapContext())
            {
                var rentalDtos = from r in context.Rentals
                                 join ca in context.Cars
                                 on r.CarId equals ca.Id
                                 join b in context.Brands
                                 on ca.BrandId equals b.Id
                                 join cu in context.Customers
                                 on r.CustomerId equals cu.Id
                                 join u in context.Users
                                 on cu.UserId equals u.Id
                                 select new RentalDto
                                 {
                                     Id = r.Id,
                                     BrandName = b.Name,
                                     CustomerName = u.FirstName + " " + u.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate
                                 };
                return rentalDtos.ToList();
            }
        }
    }
}


//from r in context.Rentals
//join ca in context.Cars on
//r.CarId equals ca.Id
//join
//b in context.Brands on
//b.Id equals ca.BrandId
//join
//cu in context.Customers on
//cu.Id equals r.CustomerId