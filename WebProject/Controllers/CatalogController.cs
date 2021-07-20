using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class CatalogController : Controller
    {
        private PetShopContext _context;

        public CatalogController(PetShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.data = _context.Animals.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        public IActionResult CategorySort(Category category)
        {
            ViewBag.data = _context.Animals.Where(a => a.CategoryId == category.CategoryId).ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View("Index");
        }

        public IActionResult ShowAnimalDetails(Animal animal)
        {
            Animal animalVm = _context.Animals.SingleOrDefault(a => a.AnimalId == animal.AnimalId);
            var commentsListVm = _context.Comments.Where(c => c.AnimalId == animalVm.AnimalId).ToList();

            AnimalDetailsViewModel vm = new AnimalDetailsViewModel { Animals = animalVm, Comments = commentsListVm };
            return View("ShowAnimalDetails",vm);
        }

        public IActionResult AddComment(Comment comment,int animalId)
        {
            Animal animalVm = _context.Animals.SingleOrDefault(a => a.AnimalId == animalId);
            Comment commentVm = new Comment { CommentString = comment.CommentString, AnimalId = animalId };
            _context.Comments.Add(commentVm);
            _context.SaveChanges();
            return RedirectToAction("ShowAnimalDetails", animalVm);
        }
    }
}
