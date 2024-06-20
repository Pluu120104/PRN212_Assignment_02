using BussinessObjectLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObject
{
    public class BookingReservationDAO
    {
        private readonly FuminiHotelManagementAsm2Context context;

        private static BookingReservationDAO instance;

        private static readonly object lockObject = new object();

        private BookingReservationDAO()
        {
        }

        public class BookingReservationWithCustomerName
        {
            public BookingReservation BookingReservation { get; set; }
            public string CustomerName { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public static BookingReservationDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new BookingReservationDAO();
                    }
                }
            }
            return instance;
        }

        public IEnumerable<BookingReservationDTO> GetBookingReservations()
        {
            using (var context = new FuminiHotelManagementAsm2Context())
            {
                var BookingReservations = context.BookingReservations
                    .Include(r => r.BookingDetails)
                    .Include(r => r.Customer)
                    .Select(r => new BookingReservationDTO
                    {
                        CustomerName = r.Customer.CustomerFullName,
                        BookingDate = r.BookingDate.HasValue ? r.BookingDate.Value.ToDateTime(new TimeOnly()) : (DateTime?)null,
                        TotalPrice = r.TotalPrice,
                        BookingStatus = r.BookingStatus,
                    })
                    .ToList();
                return BookingReservations;
            }
        }

        public IEnumerable<BookingReservationDTO> GetBookingReservations(DateTime startDate, DateTime endDate)
        {
            using (var context = new FuminiHotelManagementAsm2Context())
            {
                var BookingReservations = context.BookingReservations
                    .Include(r => r.BookingDetails)
                    .Include(r => r.Customer)
                    .Where(n => n.BookingDate.HasValue && n.BookingDate.Value.ToDateTime(new TimeOnly()) >= startDate && n.BookingDate.Value.ToDateTime(new TimeOnly()) <= endDate)
                    .Select(r => new BookingReservationDTO
                    {
                        CustomerName = r.Customer.CustomerFullName,
                        BookingDate = r.BookingDate.HasValue ? r.BookingDate.Value.ToDateTime(new TimeOnly()) : (DateTime?)null,
                        TotalPrice = r.TotalPrice,
                        BookingStatus = r.BookingStatus,
                    })
                    .ToList();
                return BookingReservations;
            }
        }

        public IEnumerable<BookingReservationWithCustomerName> GetBookingReservationByCustomerId(int customerId)
        {
            using (var context = new FuminiHotelManagementAsm2Context())
            {
                var bookingReservations = context.BookingReservations
                    .Include(r => r.BookingDetails)
                    .Include(r => r.Customer)
                    .Where(n => n.CustomerId == customerId)
                    .Select(r => new BookingReservationWithCustomerName
                    {
                        BookingReservation = r,
                        CustomerName = r.Customer.CustomerFullName,
                        TotalPrice = r.TotalPrice.Value
                    })
                    .ToList();
                return bookingReservations;
            }
        }
    }
}
