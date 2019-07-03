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
using Hotel.Domain.Enums;

namespace Hotel.WebUI.Controllers
{
    public class RoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        UnitOfWork unitOfWork = new UnitOfWork();
        public int pageSize = 3;

        public RoomsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public RoomsController()
        {
        }

        [AllowAnonymous]
        public ActionResult List(int page = 1, RoomSortBy orderBy = RoomSortBy.None, bool desc = false)
        {
            RoomViewModel roomView = new RoomViewModel
            {
                Rooms = unitOfWork.Rooms.GetAll(orderBy, desc)
                      .Skip((page - 1) * pageSize)
                      .Take(pageSize)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = unitOfWork.Rooms.Rooms.Count()
                }

            };        
            return View(roomView);
        }
        [HttpPost]
        public ActionResult List(RoomSortBy orderBy = RoomSortBy.None, bool desc = false, int page=1)
        {
            RoomViewModel roomView = new RoomViewModel
            {
                Rooms = unitOfWork.Rooms.GetAll(orderBy, desc),
                PagingInfo = new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = orderBy == RoomSortBy.None?pageSize:unitOfWork.Rooms.Rooms.Count(),
                    TotalItems = unitOfWork.Rooms.Rooms.Count()
                }
                                 };
                        return View(roomView);

        }

        public FileContentResult GetImage(int roomId)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
                return File(room.ImageData, room.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            return View(unitOfWork.Rooms.Rooms.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = unitOfWork.Rooms.GetRoomById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomId,Price,CountOfPeople,RoomClass,RoomState,ImageData,ImageMimeType,DateRentStart,DateRentEnd")] Room room)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Rooms.Create(room);
                return RedirectToAction("Index");
            }

            return View(room);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = unitOfWork.Rooms.GetRoomById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                //if (image != null)
                //{
                //    room.ImageMimeType = image.ContentType;
                //    room.ImageData = new byte[image.ContentLength];
                //    image.InputStream.Read(room.ImageData, 0, image.ContentLength);
                //}
                unitOfWork.Rooms.SaveRoom(room);

                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(room);
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = unitOfWork.Rooms.GetRoomById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.Rooms.Delete(id);
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
