using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using V8bshage.Data;
using V8bshage.Models;


namespace V8bshage.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly AdvertisementContext _adb;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager, AdvertisementContext adb)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _adb = adb;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Advertisement> advList = _adb.Advertisements;
            var user = await _userManager.GetUserAsync(User);

            ProfileViewModel profile = new ProfileViewModel
            {
                User = user,
                Advertisments = advList
            };
            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            user.LastName = "Foo";
            return View(user);
        }

        [HttpGet]
        public IActionResult RemoveAdv(int? id)
        {
            var adv = _adb.Advertisements.Find(id);
            if (adv == null)
            {
                return NotFound();
            }

            _adb.Remove(adv);
            _adb.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAdv(int? id)
        {
            var adv = _adb.Advertisements.Find(id);
            if (adv == null)
            {
                return NotFound();
            }

            return View(adv);
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        public async Task<IActionResult> UpdateAdv(Advertisement adv)
        {
            if(ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        adv.Photo = dataStream.ToArray();
                    }
                }

                _adb.Advertisements.Update(adv);
                await _adb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adv);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
