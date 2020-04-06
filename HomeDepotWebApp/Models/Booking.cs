using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime PickUpDate { get; set; }
        public string Status { get; set; }
        public int Days { get; set; }
        public int CustomerID { get; set; }
        public int ToolID { get; set; }
        public override string ToString()
        {
            return PickUpDate.ToString() + ", " + Days + ", " + Status;
        }
    }
}
