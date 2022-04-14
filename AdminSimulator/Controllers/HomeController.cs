using AdminSimulator.Data;
using AdminSimulator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdminSimulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager, 
            ILogger<HomeController> logger, 
            ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = db;
        }

        public IActionResult Index()
        {
            //return View(Account.Register);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Block(int[] selectedIds)//checkedArray)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;
            foreach (int item in selectedIds)
            {
                User user = _context.AppUsers.FirstOrDefault(p => p.UserId == item);
                if (user != null)
                {
                    user.UserStatus = "Blocked";
                    _context.Update(user);
                }
                
                if (user.UserEmail == currentUserEmail)
                    await _signInManager.SignOutAsync();
            }
            await _context.SaveChangesAsync();
            

            //if(user)
            //return RedirectToPage("Index2");
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Unblock(int[] selectedIds)//checkedArray)
        {
            foreach (int item in selectedIds)
            {
                User user = _context.AppUsers.FirstOrDefault(p => p.UserId == item);
                if (user != null)
                {
                    user.UserStatus = "Active";
                    _context.Update(user);
                }
            }
            await _context.SaveChangesAsync();
            return NoContent();
            //return RedirectToPage("Index2");
        }


        //block token
        //services.AddIdentity<User, Role>(identityOptions =>
        //{
        //    // enables immediate logout, after updating the user's stat.
        //    identityOptions.SecurityStampValidationInterval = TimeSpan.Zero;
        //}

        //await _signInManager.SignOutAsync();

        [HttpPost]
        public async Task<ActionResult> Delete(int[] selectedIds) //string id)
        {
            var users = _context.AppUsers.Where(u => selectedIds.Contains(u.UserId)).ToList();
            var currentUserEmail = HttpContext.User.Identity.Name;
            foreach (User tmp in users)
            {
                if (tmp != null)
                {
                    var user = await _userManager.FindByEmailAsync(tmp.UserEmail);
                    if (user != null)
                    {
                        IdentityResult result = await _userManager.DeleteAsync(user);//.GetAwaiter().GetResult();

                    }
                    
                    if (user.Email == currentUserEmail)
                        await _signInManager.SignOutAsync();

                    _context.AppUsers.Remove(tmp);
                }
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction("Index");
            return NoContent();
            //return RedirectToPage("Index2");
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
