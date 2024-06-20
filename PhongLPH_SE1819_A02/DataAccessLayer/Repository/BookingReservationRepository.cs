using DataAccessLayer.DataAccessObject;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.DataAccessObject.BookingReservationDAO;

namespace DataAccessLayer.Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {

        public IEnumerable<BookingReservationWithCustomerName> GetBookingReservationByCustomerId(int customerId) => BookingReservationDAO.GetInstance().GetBookingReservationByCustomerId(customerId);

        public IEnumerable<BookingReservationDTO> GetBookingReservations() => BookingReservationDAO.GetInstance().GetBookingReservations();
        public IEnumerable<BookingReservationDTO> GetBookingReservations(DateTime startDate, DateTime endDate) => BookingReservationDAO.GetInstance().GetBookingReservations(startDate, endDate);
    }
}
