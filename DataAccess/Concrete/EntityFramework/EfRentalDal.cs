using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal 
    {
        public List<RentDetailDto> GetRentDetails() 
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentDetailDto { RentalId = c.Id, CarName = c.Name, CustomerFirstName = u.FirstName, 
                                                        CustomerLastName = u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate,
                                                        DailyPrice = c.DailyPrice};

                return result.ToList();  


            }
        }

    }
}
