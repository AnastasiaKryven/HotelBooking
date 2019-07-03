using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Hotel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.Repositories
{
    public class ReviewRepository: IReviewRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ReviewRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Review> Reviews => db.Reviews;

        public void Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public Review GetReviewById(int? id)
        {
            return db.Set<Review>().Find(id);
        }

        public void Delete(int? id)
        {
            Review review  = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void Update(Review review)
        {            
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}