using System.Collections.Generic;
using System.Web.Mvc;

namespace CinemaWebApp.Models
{
    public class ViewModel
    {
        //for SaleSystem
        public IEnumerable<CinamaLib1.ScheduleItem> ScheduleItems { get; set; }
        public IEnumerable<SelectListItem> DateTimes { get; set; }
        public string SelectDateTime { get; set; }

        //for SelectSeat System
        public CinamaLib1.ScheduleItem ScheduleItem { get; set; }
        public IEnumerable<CinamaLib1.Ticket> Tickets { get; set; }
        public IEnumerable<CinamaLib1.Seat> Seats { get; set; }

        public IEnumerable<string> SoldSeatNums { get; set; }
        public string CouponNum { get; set; }

    }
}