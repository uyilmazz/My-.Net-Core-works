using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService(new InMemoryCarDal());
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
