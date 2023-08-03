using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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

        [SecuredOperation("cars.add,admin")]
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<CarDetailDto> GetCarDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
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
        //public idataresult<list<cardetaildto>> getcardetails(int carid)
        //{
        //    var dbcarlist = _cardal.getall(c => c.id == carid);
        //    list<cardetaildto> cardetaildtos = new list<cardetaildto>();
        //    foreach (var dbcar in dbcarlist)
        //    {
        //        cardetaildto cardetaildto = new cardetaildto()
        //        {
        //            carid = dbcar.id,
        //            carname = dbcar.name,
        //        };
        //        cardetaildtos.add(cardetaildto);
        //    }


        //    //var cardetaildtos = dbcarlist.select(c => new cardetaildto() 
        //    //{ 
        //    //    carname = c.name, 
        //    //    carid = carid 
        //    //}).tolist();

        //    return new successdataresult<list<cardetaildto>>(cardetaildtos);
        //}
    }
}
