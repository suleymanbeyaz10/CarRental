using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;


namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentDetailDto>> GetRentDetails();
        IDataResult<Rental> GetById(int id);
    }
}
