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
    public class RequestRepository: IRequestRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public RequestRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Request> Requests => db.Requests.ToList();

        public void Create(Request request)
        {
            db.Requests.Add(request);
            db.SaveChanges();
        }

        public void Update(Request request)
        {
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Request GetRequestById(int? id)
        {
            return db.Set<Request>().Find(id);
        }
    }
}