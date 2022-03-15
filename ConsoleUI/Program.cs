using Business.Concrete;
using Core.Entity.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //NewMethod();
            //CustomerGetAll();
            //RentallAdd();
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "araba" });
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "mavi" });
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, CarName = "a", ColorId = 1, DailyPrice = 100, ModelYear = 2012, Description = "car" });
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 1, CustomerId = 1});
            var result = rentalManager.GetRentalDetails();
            if (result.Success)
            {
                foreach (var details in result.Data)
                {
                    Console.WriteLine(details.CarName + "/" + details.CompanyName + "/" + details.RentDate + "/" + details.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine("Error");
            }



        }
        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UsersManager usersManager = new UsersManager(new EfUsersDal());
            User user = new User { EMail = "a123car@ac213aaaaaaaar.com", FirstName = "acaaaaaaaaaaaaaaaa132ar", LastName = "ac32aaaaaaaaaaaaaaa1ar", Password = "a12aaaaaaaaaaaaa3car" };
            usersManager.Add(user);
            customerManager.Add(new Customer { CompanyName = "acaaaaar", UserId = user.Id });
        }
        private static void RentallAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 2, CustomerId = 2, };
            rentalManager.Add(rental);
        }

        private static void NewMethod()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            UsersManager usersManager = new UsersManager(new EfUsersDal());
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName + "/" + customer.UserId);
            }
            Console.WriteLine("--------------------\n\n");
        }
    }
}
