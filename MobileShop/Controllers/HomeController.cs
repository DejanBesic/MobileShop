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
    public class HomeController : Controller
    {
        
        private readonly BatteryService batteryService = new BatteryService();
        private readonly CameraService cameraService = new CameraService();
        private readonly MemoryService memoryService = new MemoryService();
        private readonly ShopService shopService = new ShopService();
        private readonly RamService ramService = new RamService();
        private readonly OperativeSystemService operativeSystemService = new OperativeSystemService();
        private readonly ShopMobilesService shopMobilesService = new ShopMobilesService();
        private readonly MobileService mobileService = new MobileService();
        private readonly ImageService imageService = new ImageService();

        public ActionResult Index()
        {
            IEnumerable<ShopMobilesM> shopMobiles = shopMobilesService.FindAll();
            List<HomeMobile> homeMobiles = new List<HomeMobile>();

            foreach (ShopMobilesM sm in shopMobiles.Where(x => x.MobilesLeft > 0).OrderBy(x=> x.Price))
            {
                List<string> images = new List<string>();
                foreach(ImagesM img in imageService.FindByMobile(sm.MobileId))
                {
                    images.Add(Convert.ToBase64String(img.ImageBinary));
                }

                homeMobiles.Add(new HomeMobile()
                {
                    Id = sm.Id,
                    Name = mobileService.FindById(sm.MobileId).Name,
                    Price = sm.Price,
                    ShopId = sm.ShopId,
                    ShopName = shopService.FindById(sm.ShopId).ShopName,
                    Images = images,
                });
            }

            DropDowns dropDowns = new DropDowns()
            {
                Batteries = batteryService.FindAll(),
                Cameras = cameraService.FindAll(),
                Memories = memoryService.FindAll(),
                Shops = shopService.FindAll(),
                OperativeSystems = operativeSystemService.FindAll(),
                Rams = ramService.FindAll(),
                MaxPrice = homeMobiles.Count > 0 ? homeMobiles[homeMobiles.Count - 1].Price : 0,
                MinPrice = homeMobiles.Count > 0 ? homeMobiles[0].Price : 0,
            };
            HomeDTO homeDTO = new HomeDTO()
            {
                Drops = dropDowns,
                Mobiles = homeMobiles,
            };

            return View(homeDTO);
        }

        public ActionResult Filter()
        {

            return View("Index");
        }
    }
}