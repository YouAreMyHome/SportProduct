using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportProductMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportProductMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SportProductContext _context;
        public ProductsController(SportProductContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.OrderBy(p => p.ProductID).ToListAsync();
            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NamePro,DecriptionPro,Category,Price,ImagePro,ManufacturingDate")] Product product)
        {
            if (!new[] { "Vợt", "Bóng", "Cầu", "Đệm", "Quần áo" }.Contains(product.Category))
                ModelState.AddModelError("Category", "Category không hợp lệ.");
            if (product.ManufacturingDate >= DateOnly.FromDateTime(DateTime.Now))
                ModelState.AddModelError("ManufacturingDate", "Ngày sản xuất phải nhỏ hơn hiện tại.");

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,NamePro,Category,ManufacturingDate,Price,DecriptionPro,ImagePro")] Product product)
        {
            if (!new[] { "Vợt", "Bóng", "Cầu", "Đệm", "Quần áo" }.Contains(product.Category))
                ModelState.AddModelError("Category", "Category không hợp lệ.");
            if (product.ManufacturingDate >= DateOnly.FromDateTime(DateTime.Now))
                ModelState.AddModelError("ManufacturingDate", "Ngày sản xuất phải nhỏ hơn hiện tại.");

            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
