using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using ServiceContracts;
using ServiceContracts.DTOs;

namespace ECommerce.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        public CategoryController(ICategoriesService categoriesService, IProductsService productsService)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
        }
        // GET: HangHoas
        public async Task<IActionResult> Index(int id, string searchQuery = "")
        {
            List<ProductDTO> products = new List<ProductDTO>();
            if (id != 0)
                products = await _productsService.GetFilteredProducts(id, searchQuery);
            else
                products = await _productsService.GetAllProducts(searchQuery);

            ViewBag.SearchQuery = searchQuery;
            return View(products);
        }

        //// GET: HangHoas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hangHoa = await _context.HangHoas
        //        .Include(h => h.MaLoaiNavigation)
        //        .Include(h => h.MaNccNavigation)
        //        .FirstOrDefaultAsync(m => m.MaHh == id);
        //    if (hangHoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hangHoa);
        //}

        //// GET: HangHoas/Create
        //public IActionResult Create()
        //{
        //    ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai");
        //    ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc");
        //    return View();
        //}

        //// POST: HangHoas/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("MaHh,TenHh,TenAlias,MaLoai,MoTaDonVi,DonGia,Hinh,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(hangHoa);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
        //    ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hangHoa.MaNcc);
        //    return View(hangHoa);
        //}

        //// GET: HangHoas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hangHoa = await _context.HangHoas.FindAsync(id);
        //    if (hangHoa == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
        //    ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hangHoa.MaNcc);
        //    return View(hangHoa);
        //}

        //// POST: HangHoas/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("MaHh,TenHh,TenAlias,MaLoai,MoTaDonVi,DonGia,Hinh,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa)
        //{
        //    if (id != hangHoa.MaHh)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(hangHoa);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HangHoaExists(hangHoa.MaHh))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "MaLoai", hangHoa.MaLoai);
        //    ViewData["MaNcc"] = new SelectList(_context.NhaCungCaps, "MaNcc", "MaNcc", hangHoa.MaNcc);
        //    return View(hangHoa);
        //}

        //// GET: HangHoas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hangHoa = await _context.HangHoas
        //        .Include(h => h.MaLoaiNavigation)
        //        .Include(h => h.MaNccNavigation)
        //        .FirstOrDefaultAsync(m => m.MaHh == id);
        //    if (hangHoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hangHoa);
        //}

        //// POST: HangHoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hangHoa = await _context.HangHoas.FindAsync(id);
        //    if (hangHoa != null)
        //    {
        //        _context.HangHoas.Remove(hangHoa);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HangHoaExists(int id)
        //{
        //    return _context.HangHoas.Any(e => e.MaHh == id);
        //}
    }
}
