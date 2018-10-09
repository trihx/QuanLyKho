using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKho.Controllers
{
    public class NhomHangHoaController : Controller
    {
        //GET:
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
           return View();  
        }
       
    }
}