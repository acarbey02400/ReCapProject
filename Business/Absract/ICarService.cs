using Entities.Concrete;
using Entities.DTOs;
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
        public List<Car> GetCarsByBrandId(int BrandId);
        public List<Car> GetCarsByColorId(int ColorId);
        public List<CarDetailDto> GetCarDetails();
    }
}
