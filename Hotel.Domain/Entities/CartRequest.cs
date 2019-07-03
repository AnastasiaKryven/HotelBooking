using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class CartRequest
    {
            private List<CartLineRequest> lineCollectionRequest = new List<CartLineRequest>();

            public void AddItem(Request request, int quantity)
            {
            CartLineRequest line = lineCollectionRequest
                    .Where(g => g.Request.RequestId == request.RequestId)
                    .FirstOrDefault();

                if (line == null)
                {
                lineCollectionRequest.Add(new CartLineRequest
                    {
                        Request = request,
                        Quantity = quantity
                    });
                }
                else
                {
                    line.Quantity += quantity;
                }
            }



            public void RemoveLine(Request request)
            {
            lineCollectionRequest.RemoveAll(l => l.Request.RequestId == request.RequestId);
            }

            public decimal ComputeTotalValue()
            {

                return lineCollectionRequest.Sum(e => (decimal)(e.Request.DateExit.Day-e.Request.DateEntry.Day) * e.Quantity);

            }
            public void Clear()
            {
            lineCollectionRequest.Clear();
            }

            public IEnumerable<CartLineRequest> Lines
            {
                get { return lineCollectionRequest; }
            }
        }

        public class CartLineRequest
        {
        public int CartLineRequestId { get; set; }

        public Request Request { get; set; }
            public int Quantity { get; set; }
        }



    }
