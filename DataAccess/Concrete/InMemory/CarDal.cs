using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class CarDal : ICarDal
    {
        List<Car> _car;
        public CarDal()
        {
            _car = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=0,ModelYear=2020,DailyPrice=100,Description="araba"},
            new Car{Id=2,BrandId=2,ColorId=2,ModelYear=2015,DailyPrice=1010,Description="araba 2"},
            new Car{Id=3,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=100,Description="araba 3"},
            new Car{Id=4,BrandId=1,ColorId=0,ModelYear=2020,DailyPrice=1000,Description="araba 4"},

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
             carToDelete= _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public Car GetById(Car car)
        {
            return _car.SingleOrDefault(c => c.Id == car.Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
