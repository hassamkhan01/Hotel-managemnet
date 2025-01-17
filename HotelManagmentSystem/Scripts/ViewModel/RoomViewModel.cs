﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagmentSystem.Models;
using System.Web.Mvc;
using HotelManagmentSystem.ViewModel;
using System.ComponentModel.DataAnnotations;



namespace HotelManagmentSystem.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name ="Room No.")]

        public string RoomNumber { get; set; }
        [Display(Name = "Room Image.")]
        public string RoomImage { get; set; }
        [Display(Name = "Room Price.")]
        public decimal RoomPrice { get; set; }
        [Display(Name = "Booking Status.")]
        public int BookingStatusId { get; internal set; }
        [Display(Name = "Room Type.")]
        public int RoomTypeId { get; set; }
        [Display(Name = "Room Capacity.")]
        public int RoomCapacity { get; set; }
        
        public HttpPostedFileBase Image { get; set; }
        [Display(Name = "Room Description.")]
        public string RoomDescription { get; set; }

        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomType { get; set; }



    }
}