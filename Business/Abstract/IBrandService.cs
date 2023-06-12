using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        public void Add(Brand Brand);
        public void Update(Brand Brand);
        public void Delete(Brand Brand);
        Brand GetById(int id);
    }
}
