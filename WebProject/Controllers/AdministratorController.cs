using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdministratorController : Controller
    {
        private PetShopContext _context;
        private readonly IWebHostEnvironment hostEnv;

        public AdministratorController(PetShopContext context, IWebHostEnvironment hostEnv)
        {
            _context = context;
            this.hostEnv = hostEnv;
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

        public IActionResult EditPage(int animalId)
        {
            ViewBag.Categories = _context.Categories.ToList();
            Animal animalToEdit = _context.Animals.SingleOrDefault(a => a.AnimalId == animalId);
            return View("Edit",animalToEdit);
        }

        public IActionResult SubmitEdit(Animal animal)
        {
            ModelState.Remove("ImageFile");
            ModelState.Remove("PictureName");
            if (ModelState.IsValid)
            {
                Animal animalToEdit = _context.Animals.SingleOrDefault(a => a.AnimalId == animal.AnimalId);

                animalToEdit.Name = animal.Name;
                animalToEdit.Age = animal.Age;
                animalToEdit.CategoryId = animal.Category.CategoryId;
                animalToEdit.Description = animal.Description;

                _context.Update(animalToEdit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditPage", new { animalId = animal.AnimalId} );
        }

        public IActionResult AddNewAnimalPage()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("AddNewAnimal");
        }

        public IActionResult InsertNewAnimal(Animal animal)
        {
            ModelState.Remove("PictureName");
            //save image in wwwRoot/image folder
            if (ModelState.IsValid)
            {
                string wwwrootPath = hostEnv.WebRootPath;
                string fileName = Path.GetFileName(animal.ImageFile.FileName);
                string path = Path.Combine(wwwrootPath + "/Images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                     animal.ImageFile.CopyTo(fileStream);
                }
                _context.Add(new Animal {
                    Name = animal.Name, 
                    Age = animal.Age, 
                    CategoryId = animal.Category.CategoryId,
                    Description = animal.Description,
                    PictureName = fileName });

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("AddNewAnimalPage");
        }

        public IActionResult DeleteAnimal(Animal animal)
        {
            Animal animalToDelete = _context.Animals.SingleOrDefault(a => a.AnimalId == animal.AnimalId);
            Category catagory = animalToDelete.Category;
            if (animalToDelete != null)
                _context.Animals.Remove(animalToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
