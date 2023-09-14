using   EcommerceData.Data;
using EcommerceModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext) { _dbContext = dbContext; }

        public IActionResult Index()
        {
            List<Category> categories = _dbContext.Categories.ToList<Category>();
            return View(categories);
        }

        public IActionResult Create()
        {

            return View("AddNewCategory");
        }
        [HttpPost]
        public IActionResult AddNewCategory(Category newCategory)
        {

            // add custom error message from controller
            if (newCategory.DisplayOrder == 50)
            {
                ModelState.AddModelError("DisplayOrder", "Display Order cannot be 50");
            }


            if (newCategory != null && ModelState.IsValid)
            {
                _dbContext.Categories.Add(newCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();
            }

            // find id from primary key column.
            Category? categoryobj = _dbContext.Categories.Find(id);
            // first or defualt
            //categoryobj = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            // uses the where condition and then first or default.
            //categoryobj = _dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryobj == null)
            {
                return NotFound();
            }

            return View(categoryobj);
        }
        [HttpPost]
        public IActionResult Edit(Category newCategory)
        {

            if (newCategory != null && ModelState.IsValid)
            {
                _dbContext.Categories.Update(newCategory);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();
            }

            // find id from primary key column.
            Category? categoryobj = _dbContext.Categories.Find(id);
            // first or defualt
            //categoryobj = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            // uses the where condition and then first or default.
            //categoryobj = _dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryobj == null)
            {
                return NotFound();
            }

            return View(categoryobj);
        }
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                Category obj = _dbContext.Categories.Find(Id);
                if (obj== null)
                {

                    return NotFound();    
                }
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
