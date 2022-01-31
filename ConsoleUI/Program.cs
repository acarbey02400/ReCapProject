using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Id = 5, BrandId = 2, ColorId = 1, DailyPrice = 140, ModelYear = 2016, Description = "araba yeğen" };

            CarManager carManager = new CarManager(new CarDal());
            carManager.Add(car);
            foreach (Car car1 in carManager.GetAll())
            {
                Console.WriteLine(car1.Description);
            }
       
            Console.WriteLine("--------------------\n\n");
            carManager.Delete(car);
            foreach (Car car1 in carManager.GetAll())
            {
                Console.WriteLine(car1.Description);
            }


        }
    }
}
