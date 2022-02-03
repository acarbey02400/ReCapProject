using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDBContext context= new ReCapDBContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                              on p.BrandId equals b.Id
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             select new CarDetailDto { BrandName = b.BrandName, Id = p.Id, CarName = p.CarName, ColorName = c.ColorName, DailyPrice = p.DailyPrice, Description = p.Description, ModelYear = p.ModelYear };
                return result.ToList();
            }
        }
    }
}
