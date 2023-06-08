using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{


    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car>()
            {
                new Car { Id = 1,BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = 2017, Description = "vehicle 1"},
                new Car { Id = 2,BrandId = 4, ColorId = 3, DailyPrice = 750, ModelYear = 2020, Description = "vehicle 2"},
                new Car { Id = 3,BrandId = 2, ColorId = 1, DailyPrice = 1000, ModelYear = 2019, Description = "vehicle 3"},
                new Car { Id = 4,BrandId = 1, ColorId = 2, DailyPrice = 400, ModelYear = 2013, Description = "vehicle 4"},
                new Car { Id = 5,BrandId = 3, ColorId = 4, DailyPrice = 1300, ModelYear = 2023, Description = "vehicle 5"},
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

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.Id == CarId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            
        }
    }
}
