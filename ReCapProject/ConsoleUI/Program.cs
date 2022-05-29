using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService(new EfCarDal());
            //carService.Add(new Car
            //{
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 100,
            //    Description = "car1 description",
            //    ModelYear = 1990,
            //    Name = "BMW 2"
            //});


            foreach (var car in carService.GetCarDetailDtos())
            {
                Console.WriteLine("Car Name : {0} BrandName : {1} ColorName {2} DailyPrice : {3}", car.Carname, car.BrandName, car.ColorName, car.DailyPrice);
            }
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Name);
            //}
        }
    }
}
