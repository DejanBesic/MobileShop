using MobileShop.Models.DTO;
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
        private readonly AdditionalService additionalService = new AdditionalService();
        private readonly BatteryService batteryService = new BatteryService();
        private readonly CameraService cameraService = new CameraService();
        private readonly CharacteristicsService characteristicsService = new CharacteristicsService();
        private readonly CommunicationService communicationService = new CommunicationService();
        private readonly MemoryService memoryService = new MemoryService();
        private readonly PackageContentService packageContentService = new PackageContentService();
        private readonly PhonePlatfromService phonePlatfromService = new PhonePlatfromService();
        private readonly ScreenService screenService = new ScreenService();
        private readonly SoundService soundService = new SoundService();
        private readonly ShopService shopService = new ShopService();

        public ActionResult Index()
        {
            DropDowns dropDowns = new DropDowns()
            {
                Additionals = additionalService.FindAll(),
                Batteries = batteryService.FindAll(),
                Cameras = cameraService.FindAll(),
                Characteristics = characteristicsService.FindAll(),
                Communications = communicationService.FindAll(),
                Memories = memoryService.FindAll(),
                PackageContents = packageContentService.FindAll(),
                PhonePlatforms = phonePlatfromService.FindAll(),
                Screens = screenService.FindAll(),
                Sounds = soundService.FindAll(),
                Shops = shopService.FindAll(),
            };

            return View(dropDowns);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}