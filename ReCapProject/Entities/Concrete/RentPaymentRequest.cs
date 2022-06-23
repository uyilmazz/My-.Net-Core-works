using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RentPaymentRequest
    {
        public CrediCard CrediCard { get; set; }
        public int CustomerId { get; set; }
        public List<Rental> Rentals { get; set; }
        public double Amount { get; set; }

    }

}