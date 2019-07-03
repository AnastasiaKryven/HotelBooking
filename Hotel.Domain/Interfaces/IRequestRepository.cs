using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> Requests { get; }
        void Create(Request request);
        void Update(Request request);
        Request GetRequestById(int? id);
       
    }
}
