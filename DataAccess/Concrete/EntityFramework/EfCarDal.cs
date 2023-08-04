using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {

        public CarDetailDto GetCarDetails(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join p in context.Colors on c.ColorId equals p.ColorId
                             join i in context.CarImages on c.Id equals i.CarId into cImages
                             from ci in cImages.DefaultIfEmpty()
                             where c.Id == carId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 ColorName = p.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };

                var carDetails = result.FirstOrDefault();

                var carImages = from cI in context.CarImages
                                where cI.CarId == carId
                                select cI.ImagePath;

                //var carImagesList = from cI in context.CarImages
                //                where cI.CarId == carId
                //                select new {ArabaImagePath=cI.ImagePath};


                if (carDetails != null && carImages != null)
                {
                    carDetails.CarImages = carImages.ToList();
                }


                return carDetails;
            }
        }
    }
}
