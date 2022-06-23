using Business.Concrete;
using Core.Entities.Concrete;
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
            //AddUser(new User{ FirstName = "User 3 firstname",LastName = "User 3 lastname",Email = "user3@user3.com",Password = "123456"});
            //AddCustomer(new Customer { UserId = 3, CompanyName = "Company Four" });

            AddRental();

            //CarService carService = new CarService(new EfCarDal());
            //carService.Add(new Car
            //{
            //    BrandId = 1,
            //    ColorId = 1,
            //    DailyPrice = 100,
            //    Description = "car1 description",
            //    ModelYear = 1990,
            //    Name = "BMW 2"
            //});

            //var result = carService.GetCarDetailDtos();
            //if (result.Success)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine("Car Name : {0} BrandName : {1} ColorName {2} DailyPrice : {3}", car.Carname, car.BrandName, car.ColorName, car.DailyPrice);
            //    }
            //}

            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Name);
            //}
        }

        private static void AddRental()
        {
            //RentalService rentalService = new RentalService(new EfRentalDal());
            //var result = rentalService.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = DateTime.Now });
            //Console.WriteLine(result.Message);
        }

        private static void AddCustomer(Customer customer)
        {
            CustomerService customerService = new CustomerService(new EfCustomerDal());
            var result = customerService.Add(customer);
            Console.WriteLine(result.Message);
        }

        private static void AddUser(User user)
        {
            UserService userService = new UserService(new EfUserdal());
            var result = userService.Add(user);
            Console.WriteLine(result.Message);
        }
    }
}
