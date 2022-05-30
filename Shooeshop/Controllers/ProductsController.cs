using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shooeshop.Data;
using Shooeshop.Models;
using Shooeshop.Data.Migrations;

namespace Shooeshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        public IActionResult Create()
        {
            ProductsVM model = new ProductsVM();
        
            model.Category = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = (x.Id == model.CategoryId)
            }
            ).ToList();
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Size,CategoryId,Purpose")] ProductsVM product)
        
        {
            if (ModelState.IsValid)
            {
                Product modelToDB = new Product();

                modelToDB.Name = product.Name;
                modelToDB.Price = product.Price;
                modelToDB.Size = product.Size;
                modelToDB.Description = product.Description;
                modelToDB.CategoryId = product.CategoryId;
                modelToDB.Purpose = product.Purpose;

                _context.Add(modelToDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ProductsVM model = new ProductsVM();

            model.Category = _context.Categories.Select(categ => new SelectListItem
            {
                Text = categ.Name,
                Value = categ.Id.ToString(),
                Selected = (categ.Id == model.CategoryId)
            }
            ).ToList();

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(model);
        }
    

                
                public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);

            ProductsVM model = new ProductsVM()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                Purpose = product.Purpose,

            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Size,CategoryId,Purpose")] ProductsVM product)
        {
            Product modelToDB = await _context.Products.FindAsync(id);
            if (id != modelToDB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return View(modelToDB);
            }

            try
            {
                _context.Update(modelToDB);
                await _context.SaveChangesAsync(); 
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ProductExists(modelToDB.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
