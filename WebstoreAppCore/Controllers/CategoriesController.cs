using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebstoreAppCore.Models;

namespace WebstoreAppCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesRepository _ICatag;
        static int falgOrder = 0;

        public CategoriesController(ICategoriesRepository ICatag)
        {
            _ICatag = ICatag;
        }

        // GET: Categories
        public IActionResult Index()
        {
            return View(_ICatag.GetCategorys());
        }
       
        public IActionResult IndexOrder()
        {
            if(falgOrder==0)
            {
                falgOrder = 1;
                return View(nameof(Index), _ICatag.GetCategorysOrder(OrderCatag.Descending));

            }
            else
            {
                falgOrder = 0;
                return View(nameof(Index), _ICatag.GetCategorysOrder(OrderCatag.Assending));

            }
        }

        // GET: Categories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_ICatag.detail(id));
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CatId,CatName,CatDescrp,CatPicturePath")] Category category)
        {
            if (ModelState.IsValid)
            {
                _ICatag.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _ICatag.detail(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CatId,CatName,CatDescrp,CatPicturePath")] Category category)
        {
            if (id != category.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ICatag.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _ICatag.detail(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {              
                _ICatag.DeleteCategory(id);
         
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            if(_ICatag.detail(id)!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
