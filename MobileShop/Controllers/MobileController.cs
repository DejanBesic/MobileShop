using MobileShop.JWT;
using MobileShop.Models.DTO;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileShop.Controllers
{
    public class MobileController : Controller
    {
        private readonly BatteryService batteryService = new BatteryService();
        private readonly CameraService cameraService = new CameraService();
        private readonly MemoryService memoryService = new MemoryService();
        private readonly ShopService shopService = new ShopService();
        private readonly RamService ramService = new RamService();
        private readonly OperativeSystemService operativeSystemService = new OperativeSystemService();
        private readonly MobileService mobileService = new MobileService();

        // GET: Mobile
        public ActionResult Index()
        {
            return View();
        }

        [JwtAuthorize(Role="ADMIN")]
        public ActionResult New()
        {
            DropDowns dropDowns = new DropDowns()
            {
                Batteries = batteryService.FindAll(),
                Cameras = cameraService.FindAll(),
                Memories = memoryService.FindAll(),
                Shops = shopService.FindAll(),
                OperativeSystems = operativeSystemService.FindAll(),
                Rams = ramService.FindAll()
            };

            MobileViewModel mobileViewModel = new MobileViewModel()
            {
                DropDowns = dropDowns,
            };


            return View(mobileViewModel);
        }

        [HttpPost]
        public ActionResult Create(MobileM mobile)
        {
            RamM ram = ramService.FindById(mobile.RamId);
            MemoryM internMemory = memoryService.FindById(mobile.InternMemoryId);
            MemoryM externMemory = memoryService.FindById(mobile.ExternMemoryId);
            CameraM backCamera = cameraService.FindById(mobile.BackCameraId);
            CameraM frontCamera = cameraService.FindById(mobile.FrontCameraId);
            OperativeSystemM os = operativeSystemService.FindById(mobile.OsId);
            BatteryM battery = batteryService.FindById(mobile.BatteryId);


            if (ModelState.IsValid && ram != null && internMemory != null && externMemory != null 
                && backCamera != null && frontCamera != null && os != null && battery != null)
            {
                mobileService.Save(mobile);
            }

            return RedirectToAction("/New");
        }

    }
}