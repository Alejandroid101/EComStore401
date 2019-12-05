using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECom.Models;
using ECom.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECom.Controllers
{
    //get name of the policy
    [Authorize(Policy = "Admin Only")]
    public class AdminController : Controller
    {
        private readonly IInventory _context;

        public AdminController(IInventory product)
        {
            _context = product;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.GetProductsAsync());
        }

        public async Task<IActionResult> Test()
        {
            return View(await _context.GetProductsAsync());
        }


        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Product test = await _context.GetProductByIDAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Sku,Description,Year,Color")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var test = await _context.GetProductByIDAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Sku,Description,Year,Color,Image,Price")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateProductAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExist(product.ID))
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
            return View(product);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _context.GetProductByIDAsync(id);
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExist(int id)
        {
            Product product = await _context.GetProductByIDAsync(id);
            if (product != null)
            {
                return true;
            }
            return false;
        }
    }

}
