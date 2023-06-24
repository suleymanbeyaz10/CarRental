using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join p in context.Colors on c.ColorId equals p.ColorId
                             select new CarDetailDto { CarId = c.Id, CarName = c.Name, BrandName = b.BrandName, ColorName = p.ColorName, DailyPrice = c.DailyPrice};
                             
                return result.ToList();
            }

        }
    }
}
