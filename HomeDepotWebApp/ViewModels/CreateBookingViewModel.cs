using HomeDepotWebApp.Models;
using HomeDepotWebApp.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeDepotWebApp.ViewModels
{
    public class CreateBookingViewModel
    {
        public List<Tool> Tools { get; set; }
        public DateTime PickUpDate { get; set; }
        public int Days { get; set; }
        public Tool SelectedTool { get; set; }
        public int SelectedValue { get; set; }

        public SelectList SelectList
        {
            get { return new SelectList(Tools, nameof(Tool.Id), nameof(Tool.Name)); }
        }
        public CreateBookingViewModel()
        {
            Tools = new List<Tool>();
            HomeDepotContext _context = new HomeDepotContext();
            _context.Tools.ToList().ForEach(t=> Tools.Add(t));
        }
    }
}