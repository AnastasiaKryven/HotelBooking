using Hotel.Domain.Interfaces;
using Hotel.WebUI.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.WebUI.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IBookingRepository>().To<BookingRepository>();
            kernel.Bind<IRoomRepository>().To<RoomRepository>();
            kernel.Bind<IRequestRepository>().To<RequestRepository>();
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}