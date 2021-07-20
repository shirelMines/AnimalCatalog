using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private PetShopContext _context;

        public HomeController(PetShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mostCommented = _context.Animals.OrderByDescending(a => a.Comment.Count).Take(2).ToList();
            return View(mostCommented);
        }
    }
}
