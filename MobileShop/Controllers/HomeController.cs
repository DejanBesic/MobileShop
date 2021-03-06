﻿using MobileShop.Models.DTO;
using Models;
using PagedList;
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

        public ActionResult Index(int? page)
        {
            string sort = CheckParameter("sort");
            string search = CheckParameter("Search");
            string max = CheckParameter("Max");
            string min = CheckParameter("Min");
            var externs = CheckAndConvertParameter("Externs");
            var interns = CheckAndConvertParameter("Interns");
            var shops = CheckAndConvertParameter("Shops");
            var touches = CheckAndConvertParameter("Touches");
            var os = CheckAndConvertParameter("OS");
            var ram = CheckAndConvertParameter("Ram");
            var battery = CheckAndConvertParameter("Battery");
            var fronts = CheckAndConvertParameter("Fronts");
            var backs = CheckAndConvertParameter("Backs");
            var FMRadio = CheckParameter("FMRadio");
            var HDVoice = CheckParameter("HDVoice");
            var Port35mm = CheckParameter("Port35mm");
            double.TryParse(max, out double maxDouble);
            double.TryParse(min, out double minDouble);

            ViewBag.Search = Request.QueryString["search"];
            ViewBag.Max = Request.QueryString["max"];
            ViewBag.Min = Request.QueryString["min"];
            ViewBag.Externs = Request.QueryString["externs"];
            ViewBag.Interns = Request.QueryString["interns"];
            ViewBag.Shops = Request.QueryString["shops"];
            ViewBag.Touches = Request.QueryString["touches"];
            ViewBag.OS = Request.QueryString["os"];
            ViewBag.Ram = Request.QueryString["ram"];
            ViewBag.Battery = Request.QueryString["battery"];
            ViewBag.Fronts = Request.QueryString["fronts"];
            ViewBag.Backs = Request.QueryString["backs"];
            ViewBag.FMRadio = Request.QueryString["fmradio"];
            ViewBag.HDVoice = Request.QueryString["hdvoice"];
            ViewBag.Port35mm = Request.QueryString["port35mm"];
            ViewBag.Sort = Request.QueryString["sort"];

            IEnumerable<ShopMobilesM> shopMobiles = shopMobilesService.FindAll().Where(x =>
                x.MobilesLeft > 0 &&
                (search != null ? mobileService.FindById(x.MobileId).Name.ToLower().Contains(search.ToLower()) : true) &&
                (maxDouble != 0 ? x.Price <= maxDouble : true) &&
                (minDouble != 0 ? x.Price >= minDouble : true) &&
                (externs != null ? externs.Contains(mobileService.FindById(x.MobileId).ExternMemoryId.ToString()) : true) &&
                (interns != null ? interns.Contains(mobileService.FindById(x.MobileId).InternMemoryId.ToString()) : true) &&
                (shops != null ? shops.Contains(x.ShopId.ToString()) : true) &&
                (touches != null ? (touches.Contains("yes") && mobileService.FindById(x.MobileId).Touch) || (touches.Contains("no") && !mobileService.FindById(x.MobileId).Touch) : true) &&
                (os != null ? os.Contains(mobileService.FindById(x.MobileId).OsId.ToString()) : true) &&
                (ram != null ? ram.Contains(mobileService.FindById(x.MobileId).RamId.ToString()) : true) &&
                (battery != null ? battery.Contains(mobileService.FindById(x.MobileId).BatteryId.ToString()) : true) &&
                (fronts != null ? fronts.Contains(mobileService.FindById(x.MobileId).FrontCameraId.ToString()) : true) &&
                (backs != null ? backs.Contains(mobileService.FindById(x.MobileId).BackCameraId.ToString()) : true) &&
                (FMRadio != null ? FMRadio.Contains("True") && mobileService.FindById(x.MobileId).FMRadio : true) &&
                (HDVoice != null ? HDVoice.Contains("True") && mobileService.FindById(x.MobileId).HDVoice : true) &&
                (Port35mm != null ? Port35mm.Contains("True") && mobileService.FindById(x.MobileId).Port35mm : true)
            );

            if (sort == null || sort == "1")
            {
                shopMobiles = shopMobiles.OrderBy(x => x.Price);
            }
            else
            {
                shopMobiles = shopMobiles.OrderByDescending(x => x.Price);
            }
            List<HomeMobile> homeMobiles = new List<HomeMobile>();

            foreach (ShopMobilesM sm in shopMobiles)
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
                    MobileId = sm.MobileId,
                });
            }

            var minMax = shopMobilesService.FindAll().OrderBy(x => x.Price).ToList();

            DropDowns dropDowns = new DropDowns()
            {
                Batteries = batteryService.FindAll(),
                Cameras = cameraService.FindAll(),
                Memories = memoryService.FindAll(),
                Shops = shopService.FindAll(),
                OperativeSystems = operativeSystemService.FindAll(),
                Rams = ramService.FindAll(),
                MaxPrice = minMax.Count > 0 ? minMax[minMax.Count - 1].Price : 0,
                MinPrice = minMax.Count > 0 ? minMax[0].Price : 0,
            };
            HomeDTO homeDTO = new HomeDTO()
            {
                Drops = dropDowns,
                Mobiles = homeMobiles.ToPagedList(page ?? 1, 3),
            };

            return View(homeDTO);
        }

        public ActionResult Filter()
        {

            return View("Index");
        }

        private List<string> CheckAndConvertParameter(string parameter)
        {
            return string.IsNullOrWhiteSpace(Request.QueryString[parameter]) ? null : Request.QueryString[parameter].Split(',').ToList();
        }

        private string CheckParameter(string parameter)
        {
            return string.IsNullOrWhiteSpace(Request.QueryString[parameter]) ? null : Request.QueryString[parameter];
        }
    }
}