using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagmentSystem.Models;
using HotelManagmentSystem.ViewModel;
using System.IO;


namespace HotelManagmentSystem.Controllers
{
    public class RoomController : Controller
    {
        private HotelDBEntities objHotelDBEntities;

        public RoomController()
        {
            objHotelDBEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in objHotelDBEntities.BookingStatus
                                                    select new SelectListItem()
                                                    {
                                                        Text = obj.Bookingstatus,
                                                        Value = obj.BookingstatusId.ToString()
                                                    }).ToList();

            objRoomViewModel.ListOfRoomType = (from obj in objHotelDBEntities.RoomTypes
                                               select new SelectListItem()
                                               {
                                                   Text = obj.RoomTypeName,
                                                   Value = obj.RoomTypeId.ToString()
                                               }).ToList();

            return View(objRoomViewModel);

        }
        [HttpPost]
        public ActionResult Index(RoomViewModel objRoomViewModel)
        {
            string ImageUniqueName = Guid.NewGuid().ToString();
            string ActualImageName = ImageUniqueName + Path.GetExtension(objRoomViewModel.Image.FileName);

            objRoomViewModel.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));
            //objHotelDBEntities
            Room objRoom = new Room()
            {
                RoomNumber = objRoomViewModel.RoomNumber,
                RoomDescription = objRoomViewModel.RoomDescription,
                RoomPrice = objRoomViewModel.RoomPrice,
                BookingStatusId = objRoomViewModel.BookingStatusId,
                RoomImage = ActualImageName,
                RoomCapacity = objRoomViewModel.RoomCapacity,
                RoomTypeId = objRoomViewModel.RoomTypeId
            };
            objHotelDBEntities.Rooms.Add(objRoom);
            objHotelDBEntities.SaveChanges();
            return Json(data:new { message = "Room Succesfully Added.", success = true }, JsonRequestBehavior.AllowGet);

        }
        
    }
    }