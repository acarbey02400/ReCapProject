using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absract
{
   public interface ICarService
    {

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
    }
}
