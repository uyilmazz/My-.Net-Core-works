using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using(ReCapContext context = new ReCapContext())
            {
                var carDetailDtos = from ca in context.Cars
                                    join b in context.Brands on
                                    ca.BrandId equals b.Id
                                    join c in context.Colors
                                    on ca.ColorId equals c.Id
                                    select new CarDetailDto { Id = ca.Id,CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice,Description = ca.Description,ModelYear = ca.ModelYear };
                return carDetailDtos.ToList();
            }
        }
    }
}
