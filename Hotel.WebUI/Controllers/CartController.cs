using Hotel.Domain.Entities;
using Hotel.WebUI.DI;
using Hotel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.Controllers
{
    public class CartController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public CartController()
        {
        }

        public CartController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [Authorize]
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            }
                );
        }

        [Authorize]
        public ViewResult IndexRequest(CartRequest cart, string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            }
                );
        }

        public RedirectToRouteResult AddToCart(Cart cart, int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
               cart.AddItem(room, 1);
                room.RoomState = Domain.Enums.State.Booked;
                unitOfWork.Rooms.Update(room);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddRequestToCart(CartRequest cart, int requestId, string returnUrl)
        {
            Request request = unitOfWork.Requests.Requests
                .FirstOrDefault(g => g.RequestId == requestId);

            if (request != null)
            {
                cart.AddItem(request, 1);
                //request. = Domain.Enums.State.Booked;
                //unitOfWork.Rooms.Update(room);
            }
            return RedirectToAction("IndexRequest", new { returnUrl });

        }

        public string Pay(Cart cart, int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
               .FirstOrDefault(g => g.RoomId == roomId);

            room.RoomState = Domain.Enums.State.Busy;
            unitOfWork.Rooms.Update(room);

            if (room != null)
            {
                cart.RemoveLine(room);
            }

            return "Thank You "+ User.Identity.Name + " !";
        }

        public string PayRequest(CartRequest cart, int requestId, string returnUrl)
        {
            Request request = unitOfWork.Requests.Requests
               .FirstOrDefault(g => g.RequestId == requestId);
            


            //room.RoomState = Domain.Enums.State.Busy;
            //unitOfWork.Rooms.Update(room);

            if (request != null)
            {
                cart.RemoveLine(request);
            }

            return "Thank You "+ User.Identity.Name + " !";
        }



        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public PartialViewResult SummaryRequest(CartRequest cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int roomId, string returnUrl)
        {
            Room room = unitOfWork.Rooms.Rooms
                .FirstOrDefault(g => g.RoomId == roomId);

            if (room != null)
            {
                cart.RemoveLine(room);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCartRequest(CartRequest cart, int requestId, string returnUrl)
        {
            Request request = unitOfWork.Requests.Requests
              .FirstOrDefault(g => g.RequestId == requestId);

            if (request != null)
            {
                cart.RemoveLine(request);
            }
            return RedirectToAction("IndexRequest", new { returnUrl });
        }
    }
}