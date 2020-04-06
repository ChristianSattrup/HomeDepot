using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using HomeDepotWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWebApp.Controllers
{
    public class BookingController : Controller 
    {
        public ActionResult ViewBooking()
        {
            HomeDepotContext _context = new HomeDepotContext();
            Customer customer = Session["user"] as Customer;
            List<Booking> bookings = new List<Booking>();
            if (customer!=null)
            {
                _context.Bookings.ToList().ForEach((e) => {
                    if (e.CustomerID == customer.Id)
                    {
                        bookings.Add(e);
                    }
                });
                var bookingsViewlModel = new BookingsViewModel();
                bookingsViewlModel.bookings = bookings;
                return View(bookingsViewlModel);
            }
            else
            {
                return Redirect("/login/login");
            }
        }
        public ActionResult CreateForm()
        {
            HomeDepotContext _context = new HomeDepotContext();
            var createBookingViewModel = new CreateBookingViewModel();
            return View(createBookingViewModel);
        }
        public ActionResult Create(CreateBookingViewModel createBookingViewModel)
        {
            HomeDepotContext _context = new HomeDepotContext();
            Customer customer = Session["user"] as Customer;
            if (customer != null)
            {
                Tool tool = _context.Tools.Find(createBookingViewModel.SelectedValue);
                Booking booking = new Booking();
                booking.Status = "Booked";
                booking.PickUpDate = createBookingViewModel.PickUpDate;
                booking.Days = createBookingViewModel.Days;
                booking.ToolID = tool.Id;
                booking.CustomerID = customer.Id;
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return Redirect("/booking/viewbooking");
            } else
            {
                return Redirect("/login/login");
            }
        }
    }
}