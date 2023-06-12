using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;


namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(Car car);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<CarDetailDto> GetCarDetails();
        
    }
}
