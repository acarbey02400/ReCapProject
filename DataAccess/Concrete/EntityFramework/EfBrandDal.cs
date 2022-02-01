﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }

}