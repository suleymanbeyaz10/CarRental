using Core.Utilities.Results;
using Entities.Concrete;
using System;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer cutomer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
    }
}
