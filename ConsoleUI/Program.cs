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
            Brand brand = new Brand() {  BrandName = "neblm" };
            Color color = new Color() {  ColorName = "siyah" };
            Car car = new Car() { BrandId = 1, ColorId = 1, DailyPrice = 140, ModelYear = 2016, Description = "araba yeğen",CarName="BMW" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            brandManager.Add(brand);
            colorManager.Add(color);
            carManager.Add(car);
            foreach (Car car1 in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car1.CarName,"\n",car1.BrandId);
            }
       
            Console.WriteLine("--------------------\n\n");
          


        }
    }
}
