using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Domain.Entities;
using Hotel.WebUI.Models;
using Hotel.WebUI.DI;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Hotel.WebUI.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        UnitOfWork unitOfWork = new UnitOfWork();

        public BookingsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookingsController()
        {
        }

        [Authorize(Roles ="admin, manager")]
        public ActionResult Index()
        {
            unitOfWork.Requests.Requests.ToList();
            return View(unitOfWork.Requests.Requests.ToList());
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        [Authorize]
        public ActionResult Create(int? RoomId)
        {
            return View();
        }

      

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,DateEntry,DateExit,RoomId")] Request request, int?RoomId, int CountOfPlace)
        {
           
            if (ModelState.IsValid)
            {
                unitOfWork.Requests.Create(request);
                request.CountOfPlace = CountOfPlace;
               
                unitOfWork.Requests.Update(request);
                return RedirectToAction("AddRequestToCart", "Cart", request);
            }
            return View(request);
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Booking booking = await db.Bookings.FindAsync(id);
            Request request = unitOfWork.Requests.GetRequestById(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        public RedirectToRouteResult AddToBooking(int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            Booking booking = new Booking();
            //booking.DateEntry = room.DateStart;
            //booking.DateExit = room.DateEnd;
            booking.RoomId = roomId;

            if (room != null)
            {
                unitOfWork.Bookings.Create(booking);
                    
            }

            return RedirectToAction("List", new { returnUrl });
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = "admin, manager")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = await db.Requests.FindAsync(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Bookings/Delete/5
        [Authorize(Roles = "admin, manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Request request = await db.Requests.FindAsync(id);
            db.Requests.Remove(request);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
