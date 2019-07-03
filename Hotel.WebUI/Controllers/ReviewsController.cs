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

namespace Hotel.WebUI.Controllers
{
    public class ReviewsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public int pageSize = 5;


        [AllowAnonymous]
        public ActionResult List(int page = 1)
        {

            ReviewViewModel roomView = new ReviewViewModel
            {
                Reviews = unitOfWork.Reviews.Reviews
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                     ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = unitOfWork.Reviews.Reviews.Count()
                }

            };

            return View(roomView);
        }

        [HttpGet]
        public ActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedback(Review review)
        {
            unitOfWork.Reviews.Create(review);

            return RedirectToAction("Index");
        }

        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            return View(unitOfWork.Reviews.Reviews.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = unitOfWork.Reviews.GetReviewById(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

       


        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = unitOfWork.Reviews.GetReviewById(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,TextOfReview,Date,Name")] Review review)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Reviews.Update(review);
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = unitOfWork.Reviews.GetReviewById(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Reviews.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
