using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
                                    select new CarDetailDto { Id = ca.Id, CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear };
                return carDetailDtos.ToList();


            }
        }

        public List<CarDetailDto> GetCarDetailDtosByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDetailDtos = from ca in context.Cars
                                    join b in context.Brands on
                                    ca.BrandId equals b.Id
                                    join c in context.Colors
                                    on ca.ColorId equals c.Id
                                    where ca.BrandId == brandId
                                    select new CarDetailDto { Id = ca.Id, CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear };
                return carDetailDtos.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailDtosByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDetailDtos = from ca in context.Cars
                                    join b in context.Brands on
                                    ca.BrandId equals b.Id
                                    join c in context.Colors
                                    on ca.ColorId equals c.Id
                                    where ca.ColorId == colorId
                                    select new CarDetailDto { Id = ca.Id, CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear };
                return carDetailDtos.ToList();
            }
        }

        public CarDetailDto GetCarDetailDtoByCarId(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDetailDto = from ca in context.Cars
                                    join b in context.Brands on
                                    ca.BrandId equals b.Id
                                    join c in context.Colors
                                    on ca.ColorId equals c.Id
                                    where ca.Id == carId
                                    select new CarDetailDto { Id = ca.Id, CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear,FindexScore = ca.FindexScore };
                return carDetailDto.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetFilteredCarDetailDtos(int colorId, int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carDetailDtos = from ca in context.Cars
                                    join b in context.Brands on
                                    ca.BrandId equals b.Id
                                    join c in context.Colors
                                    on ca.ColorId equals c.Id
                                    where ca.ColorId == colorId && ca.BrandId == brandId
                                    select new CarDetailDto { Id = ca.Id, CarName = ca.Name, BrandName = b.Name, ColorName = c.Name, DailyPrice = ca.DailyPrice, Description = ca.Description, ModelYear = ca.ModelYear };
                return carDetailDtos.ToList();
            }
        }
    }
}
