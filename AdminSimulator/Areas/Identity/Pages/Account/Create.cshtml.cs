using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminSimulator.Data;
using AdminSimulator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminSimulator.Areas.Identity.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public User User { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User.RegisterDate = DateTime.Now;
                User.LastActiveDate = DateTime.Now;
                User.UserStatus = "Active";
                _context.AppUsers.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
