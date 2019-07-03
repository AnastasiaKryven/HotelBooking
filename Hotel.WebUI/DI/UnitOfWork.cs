using Hotel.Domain.Interfaces;
using Hotel.WebUI.Models;
using Hotel.WebUI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.WebUI.DI
{
    public class UnitOfWork
    {
        ApplicationDbContext db = new ApplicationDbContext();
        IBookingRepository bookingRepository;
        IReviewRepository reviewRepository;
        IRoomRepository roomRepository;
        IRequestRepository requestRepository;

        public IRequestRepository Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(db);
                return requestRepository;
            }
        }

        public IBookingRepository Bookings
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }

        public IReviewRepository Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(db);
                return roomRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}