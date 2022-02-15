using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDBContext>, IRentalDal
    {
        public List<RentalsDetailDto> GetRentalDetails()
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var result = from p in context.Rentals
                             join c in context.Cars
                              on p.CarId equals c.Id
                             join ct in context.Customers   
                             on p.CustomerId equals ct.Id
                             select new RentalsDetailDto {CarName=c.CarName, CompanyName=ct.CompanyName, 
                                 RentDate=p.RentDate, ReturnDate=p.ReturnDate, Id=p.Id };
                return result.ToList();
            }
        }
    }
}
