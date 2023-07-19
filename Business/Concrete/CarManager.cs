using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId), "Ürünler listelendi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(co => co.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
        //public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        //{
        //    var dbCarList = _carDal.GetAll(c => c.Id == carId);
        //    List<CarDetailDto> carDetailDtos = new List<CarDetailDto>();
        //    foreach (var dbCar in dbCarList)
        //    {
        //        CarDetailDto carDetailDto = new CarDetailDto()
        //        {
        //            CarId = dbCar.Id,
        //            CarName = dbCar.Name,
        //        };
        //        carDetailDtos.Add(carDetailDto);
        //    }


        //    //var carDetailDtos = dbCarList.Select(c => new CarDetailDto() 
        //    //{ 
        //    //    CarName = c.Name, 
        //    //    CarId = carId 
        //    //}).ToList();

        //    return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos);
        //}
    }
}
