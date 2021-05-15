using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using V8bshage.Data;
using V8bshage.Models;

namespace V8bshage.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly AdvertisementContext _adb;

        public AdvertisementController(AdvertisementContext adb)
        {
            _adb = adb;
        }

        public IActionResult Index()
        {
            IEnumerable<Advertisement> advList = _adb.Advertisements;
            return View(advList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
