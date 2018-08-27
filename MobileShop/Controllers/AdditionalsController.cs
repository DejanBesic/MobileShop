﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

namespace MobileShop.Controllers
{
    public class AdditionalsController : Controller
    {
        private readonly AdditionalService additionalService = new AdditionalService();

        // GET: Additionals
        public ActionResult Index()
        {
            return View();
        }

        // GET: Additionals/All
        public JsonResult All()
        {
            return Json(additionalService.FindAll(), JsonRequestBehavior.AllowGet);
        }

        // GET: Additionals/One/{id}
        public JsonResult One(int id)
        {
            return Json(additionalService.FindById(id), JsonRequestBehavior.AllowGet);
        }

        // POST: Additionals/Save
        [HttpPost]
        public JsonResult Save(AdditionalM additional)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }

            return Json(additionalService.Save(additional), JsonRequestBehavior.AllowGet);
        }

        // GET: Additionals/Delete/{id}
        public JsonResult Delete(int id)
        {
            return Json(additionalService.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}