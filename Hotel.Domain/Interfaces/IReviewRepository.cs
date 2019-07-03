using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Reviews { get; }

        void Create(Review review);

        Review GetReviewById(int? id);

        void Delete(int? id);

        void Update(Review review);
    }
}
