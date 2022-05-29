using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 2,DailyPrice = 3000,Description = "Car1 Description",ModelYear = 1990},
                new Car{Id = 2,BrandId = 1,ColorId = 2,DailyPrice = 2500,Description = "Car2 Description",ModelYear = 2001},
                new Car{Id = 3,BrandId = 2,ColorId = 1,DailyPrice = 1500,Description = "Car3 Description",ModelYear = 1995},
                new Car{Id = 4,BrandId = 2,ColorId = 1,DailyPrice = 2250,Description = "Car4 Description",ModelYear = 2015},
                new Car{Id = 5,BrandId = 2,ColorId = 1,DailyPrice = 2150,Description = "Car5 Description",ModelYear = 2010},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateToCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateToCar.DailyPrice = car.DailyPrice;
            updateToCar.ModelYear = car.ModelYear;
            updateToCar.BrandId = car.BrandId;
            updateToCar.ColorId = car.ColorId;
            updateToCar.Description = car.Description;
        }
    }
}
