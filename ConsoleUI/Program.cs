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
            carManager.Add(new Car { BrandId = 3, CarName = "Porsche", ColorId = 2, DailyPrice = 500, Description = "Araba egan", ModelYear = 2021 });

            var result = carManager.GetCarDetails();
            
            foreach (var car1 in result.Data)
            {
                Console.WriteLine(car1.CarName+"/"+car1.BrandName+"/"+car1.ColorName+"/"+car1.Id);
            }
       
            Console.WriteLine("--------------------\n\n");
          


        }
    }
}
