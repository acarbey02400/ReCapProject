using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            carManager.Add(new Car { BrandId = 2, CarName = "Mercedes", ColorId = 3, DailyPrice = 220, Description = "Araba egan", ModelYear = 2019 });
            foreach (var car1 in carManager.GetCarDetails())
            {
                Console.WriteLine(car1.CarName+"/"+car1.BrandName+"/"+car1.ColorName+"/"+car1.Id);
            }
       
            Console.WriteLine("--------------------\n\n");
          


        }
    }
}
