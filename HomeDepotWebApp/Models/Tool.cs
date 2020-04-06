using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Deposit { get; set; }
        public int DailyRent { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}