using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult MyHeading()
        {

            var values = headingManager.GetListByWriter();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewMyHeading()
        {
            List<SelectListItem> valueCategoryy = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.vlcc = valueCategoryy;
            return View();
        }
        [HttpPost]
        public IActionResult NewMyHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = 4;
            headingManager.HeadingAdd(p);
            return RedirectToAction("MyHeading");
            
        }
        [HttpGet]
        public IActionResult EditMyHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingvalue = headingManager.GetByID(id);
            return View(headingvalue);
        }
        [HttpPost]
        public IActionResult EditMyHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public IActionResult DeleteMyHeading(int id)
        {
            var Myheadingvalue = headingManager.GetByID(id);
            Myheadingvalue.HeadingStatus = false;
            headingManager.HeadingUpdate(Myheadingvalue);
            return RedirectToAction("MyHeading");
        }
    }
}
