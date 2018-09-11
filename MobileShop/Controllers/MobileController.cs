using MobileShop.JWT;
using MobileShop.Models;
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
        private readonly ShopMobilesService shopMobilesService = new ShopMobilesService();
        private readonly AuthService authService = new AuthService();
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

        [JwtAuthorize(Role="ADMIN")]
        public ActionResult All()
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);

            return View(mobileService.FindAll().Where(x => shopMobilesService.FindByShopAndMobile(admin.ShopAdminId, x.Id) == null));
        }

        [HttpPost]
        [JwtAuthorize(Role ="ADMIN")]
        public ActionResult Add(MobileShopDTO mobileShop)
        {
            CustomerM customer = authService.DecodeJWT(User.Identity.Name);
            ShopMobilesM foundPair = shopMobilesService.FindByShopAndMobile(customer.ShopAdminId, mobileShop.MobileId);
            if (foundPair == null)
            {
                shopMobilesService.Save(new ShopMobilesM()
                {
                    MobileId = mobileShop.MobileId,
                    MobilesLeft = mobileShop.Amount,
                    ShopId = customer.ShopAdminId,
                    Price = mobileShop.Price,
                });
            }

            return RedirectToAction("All");
        }


        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Manage()
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);
            IEnumerable<ShopMobilesM> shopMobiles = shopMobilesService.FindAll().Where(x => x.ShopId == admin.ShopAdminId);

            List<MobileDTO> mobileDTOs = new List<MobileDTO>();
            foreach (var m in shopMobiles)
            {
                MobileM mobile = mobileService.FindById(m.MobileId);
                mobileDTOs.Add(new MobileDTO() { Id = m.MobileId, Amount = m.MobilesLeft, Price = m.Price, Name = mobile.Name });
            }

            return View(mobileDTOs);
        }

        [HttpPut]
        [JwtAuthorize(Role = "ADMIN")]
        public ActionResult Edit(MobileDTO mobileDTO)
        {
            CustomerM admin = authService.DecodeJWT(User.Identity.Name);
            ShopMobilesM shopMobiles = shopMobilesService.FindByShopAndMobile(admin.ShopAdminId, mobileDTO.Id);
            if (shopMobiles != null)
            {
                shopMobiles.Price = mobileDTO.Price;
                shopMobiles.MobilesLeft = mobileDTO.Amount;
                shopMobilesService.Edit(shopMobiles);
            }

            return RedirectToAction("Manage");
        }

    }
}