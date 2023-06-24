using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentDetailDto> GetRentDetails();
    }
}
