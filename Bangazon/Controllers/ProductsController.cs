using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Bangazon.Models;
using Bangazon.Models.OrderViewModels;
using Bangazon.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        //adams notes start here
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Cart()
        {
            var user = await GetUserAsync();

            var order = await _context.Order
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product) //minute 14:30
                .FirstOrDefaultAsync(o =>  o.UserId == user.Id && o.PaymentTypeId == null); //also get list of order products w/ .include
           
            var totalCost = order.OrderProducts.Sum(op => op.Product.Price);

            //PaymentType.ToListAsync is bad bc it would ... 21:00 allow you to use whatevrr payment
            var paymentTypes = await _context.PaymentType.Where(pt => pt.UserId == user.Id).ToListAsync();
            //convert into select list items

            var paymentOptions = paymentTypes.Select(pt => new SelectListItem
            {
                Value = pt.PaymentTypeId.ToString(),
                Text = pt.Description
            
            }).ToList();

            //ready to make view model now


            var viewModel = new ShoppingCartViewModel
            {
                TotalCost = totalCost,
                User = user,
                PaymentOptions = paymentOptions,
                SelectedPaymentId = paymentTypes.FirstOrDefault().PaymentTypeId,

                //default to something by using.... firstOrDefault
                OrderDetails = new OrderDetailViewModel()
                {
                    Order = order,
                    LineItems = order.OrderProducts
                    .GroupBy(op => op.ProductId)
                    .Select(group => new OrderLineItem
                    {
                        Units = group.Count(),
                        Product = group.FirstOrDefault().Product,
                    //min 40 on xbox recording .. give me first one and let me know about the product
                    // Cost = group.FirstOrDefault().Product.Price * group.Count()
                    Cost = group.Sum(op => op.Product.Price)
                    })

                }

            };

            return View(viewModel);
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            var user = await GetCurrentUserAsync();
            if (searchString == null)
            {
                var model = _context.Product
                    .Include(p => p.ProductType)
                    .Include(p => p.User);
                return View(await model.ToListAsync());
            }
            else
            {
                var model = _context.Product
                 .Include(p => p.ProductType)
                 .Include(p => p.User)
                 .Where(p => p.Title.Contains(searchString) || p.ProductType.Label.Contains(searchString) || p.City.Contains(searchString));
                return View(await model.ToListAsync());
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
           

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> CreateAsync()
        {
            var viewModel = new ProductCreateViewModel();
            var user = await GetCurrentUserAsync();
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View(viewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,DateCreated,Description,Title,Price,Quantity,UserId,City,ImagePath,Active,ProductTypeId,LocalDelivery,File")] ProductCreateViewModel viewModel, IFormFile image)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            var user = await GetCurrentUserAsync();

            viewModel.Active = true;
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Active = viewModel.Active,
                    City = viewModel.City,
                    Description = viewModel.Description,
                    LocalDelivery = viewModel.LocalDelivery,
                    Title = viewModel.Title,
                    Price = viewModel.Price,
                    Quantity = viewModel.Quantity,
                    ProductTypeId = viewModel.ProductTypeId,
                };
                if (viewModel.File != null && viewModel.File.Length > 0)
                {
                    var fileName = Path.GetFileName(viewModel.File.FileName); //getting path of actual file name
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName); //creating path combining file name w/ www.root\\images directory
                    using (var fileSteam = new FileStream(filePath, FileMode.Create)) //using filestream to get the actual path 
                    {
                        await viewModel.File.CopyToAsync(fileSteam);
                    }
                    product.ImagePath = fileName;
                }
                product.UserId = user.Id;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", viewModel.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", viewModel.UserId);
            return View(viewModel);

        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DateCreated,Description,Title,Price,Quantity,UserId,City,ImagePath,Active,ProductTypeId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}