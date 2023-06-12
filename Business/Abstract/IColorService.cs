using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        public void Add(Color color);
        public void Update(Color color);
        public void Delete(Color color);
        Color GetById(int id);
    }
}
