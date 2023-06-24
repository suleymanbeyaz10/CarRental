using Core.Utilities.Results;
using Entities.Concrete;
using System;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand Brand);
        IResult Delete(Brand Brand);
        IResult Update(Brand Brand);
        IDataResult<Brand> GetById(int id);
    }
}
