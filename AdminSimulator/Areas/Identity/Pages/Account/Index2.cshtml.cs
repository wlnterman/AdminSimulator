using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminSimulator.Data;
using AdminSimulator.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminSimulator.Areas.Identity.Pages.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<User> Users { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            Users = _context.AppUsers.ToList();
            //Users = _context.AppUsers.AsNoTracking().ToList();
        }
    }
}
