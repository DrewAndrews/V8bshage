﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace V8bshage.Controllers
{
    public class NewsController : Controller
    {
        //GET: /News/
        public string Index()
        {
            return "Default";
        }

        public string Welcome()
        {
            return "Welcome page!";
        }
    }
}
