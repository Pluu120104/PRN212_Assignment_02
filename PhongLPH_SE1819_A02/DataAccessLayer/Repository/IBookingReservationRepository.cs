using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataAccessObject.BookingReservationDAO;

namespace DataAccessLayer.Repository
{
    public interface IBookingReservationRepository
    {
        public IEnumerable<BookingReservationWithCustomerName> GetBookingReservationByCustomerId(int customerId);
        public IEnumerable<BookingReservationDTO> GetBookingReservations();

        public IEnumerable<BookingReservationDTO> GetBookingReservations(DateTime startDate, DateTime endDate);

    }
}
