using MobileShop.JWT;
using MobileShop.Models;
using MobileShop.Models.DTO;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ImageService imageService = new ImageService();

        // GET: Mobile
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult One(int id)
        {
            ShopMobilesM shopMobiles = shopMobilesService.FindById(id);
            if (shopMobiles == null)
            {

                return RedirectToAction("Index", "Home");
            }
            List<string> images = new List<string>();
            foreach (ImagesM img in imageService.FindByMobile(shopMobiles.MobileId))
            {
                images.Add(Convert.ToBase64String(img.ImageBinary));
            }
            MobileM mobile = mobileService.FindById(shopMobiles.MobileId);
            CameraM backCamera = cameraService.FindById(mobile.BackCameraId);
            CameraM frontCamera = cameraService.FindById(mobile.FrontCameraId);
            RamM ram = ramService.FindById(mobile.RamId);
            MemoryM internMemory = memoryService.FindById(mobile.InternMemoryId);
            MemoryM externMemory = memoryService.FindById(mobile.ExternMemoryId);
            OperativeSystemM operatingSystem = operativeSystemService.FindById(mobile.OsId);
            BatteryM battery = batteryService.FindById(mobile.BatteryId);

            return View(new OneMobile()
            {
                Shop = shopService.FindById(shopMobiles.ShopId),
                Images = images,
                Price = shopMobiles.Price,
                About = mobile.About,
                AdditionalDescription = mobile.AdditionalDescription,
                BackCamera = backCamera != null ? backCamera.MP : "",
                FrontCamera = frontCamera != null ? frontCamera.MP : "",
                BackCameraChar = mobile.BackCameraChar,
                BatteryCapacity = battery != null ? battery.Capacity : "",
                Bluetooth = mobile.Bluetooth,
                DataTransfer = mobile.DataTransfer,
                Dimensions = mobile.Dimensions,
                DualSIM = mobile.DualSIM,
                ExternMemory = externMemory != null ? externMemory.Size : "",
                FMRadio = mobile.FMRadio,
                FrontCameraChar = mobile.FrontCameraChar,
                GPS = mobile.GPS,
                HDVoice = mobile.HDVoice,
                Id = mobile.Id,
                InternMemory = internMemory != null ? internMemory.Size : "",
                Name = mobile.Name,
                Network2G = mobile.Network2G,
                Network3G = mobile.Network3G,
                Network4G = mobile.Network4G,
                NFC = mobile.NFC,
                OperatingSystem = operatingSystem != null ? operatingSystem.OS : "",
                PackageContent = mobile.PackageContent,
                PhoneMessages = mobile.PhoneMessages,
                PhoneWeight = mobile.PhoneWeight,
                Port35mm = mobile.Port35mm,
                Proccessor = mobile.Proccessor,
                RAM = ram != null ? ram.Memory : "",
                Resolution = mobile.Resolution,
                ScreenSize = mobile.ScreenSize,
                ScreenType = mobile.ScreenType,
                SIM = mobile.SIM,
                Touch = mobile.Touch,
                USB = mobile.USB,
                Video = mobile.Video,
                WiFi = mobile.WiFi,
            });
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
                Mobile = new NewMobileDTO()
                {
                    Mobile = new MobileM(),
                    Images = new List<HttpPostedFileBase>(),
                }
            };


            return View(mobileViewModel);
        }

        [HttpPost]
        public ActionResult Create(NewMobileDTO mobileDTO)
        {

            MobileM mobile = mobileDTO.Mobile;
            RamM ram = ramService.FindById(mobile.RamId);
            MemoryM internMemory = memoryService.FindById(mobile.InternMemoryId);
            MemoryM externMemory = memoryService.FindById(mobile.ExternMemoryId);
            CameraM backCamera = cameraService.FindById(mobile.BackCameraId);
            CameraM frontCamera = cameraService.FindById(mobile.FrontCameraId);
            OperativeSystemM os = operativeSystemService.FindById(mobile.OsId);
            BatteryM battery = batteryService.FindById(mobile.BatteryId);
            IEnumerable<HttpPostedFileBase> Images = mobileDTO.Images;
            if (Images == null)
            {
                return RedirectToAction("/New");
            }

            if (ModelState.IsValid && ram != null && internMemory != null && externMemory != null 
                && backCamera != null && frontCamera != null && os != null && battery != null)
            {
                MobileM tempMobile = mobileService.Save(mobile);


                foreach (var image in Images)
                {
                    MemoryStream target = new MemoryStream();
                    image.InputStream.CopyTo(target);
                    imageService.Save(new ImagesM() { MobileId = tempMobile.Id, ImageBinary = target.ToArray() });
                }
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