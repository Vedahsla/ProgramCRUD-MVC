using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramCRUD.Models;
using ProgramCRUD.Services;

namespace ProgramCRUD.Controllers
{
    public class DosenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DosenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dosen
        public async Task<IActionResult> Index()
        {
            var listData = await _context.Dosen.ToListAsync();
            return View(listData);
        }

        // GET: Dosen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DosenID,Name,NIP,Gender,Telephone,Address,Active")] Dosen dosen)
        {
            if (string.IsNullOrWhiteSpace(dosen.Gender) || dosen.Gender == "0")
            {
                ModelState.AddModelError("Gender", "Please select a gender!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(dosen);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Data created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(dosen);
        }

        // GET: Dosen/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var dosen = await _context.Dosen.FindAsync(id);
            if (dosen == null)
            {
                return NotFound();
            }
            return View(dosen);
        }

        // POST: Dosen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DosenID,Name,NIP,Gender,Telephone,Address,Active")] Dosen dosen)
        {
            if (id != dosen.DosenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosen);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Data updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Dosen.Any(e => e.DosenID == dosen.DosenID))
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
            return View(dosen);
        }

        // GET: Dosen/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var dosen = await _context.Dosen.FirstOrDefaultAsync(m => m.DosenID == id);
            if (dosen == null)
            {
                return NotFound();
            }

            return View(dosen);
        }

        // GET: Dosen/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var dosen = await _context.Dosen.FirstOrDefaultAsync(m => m.DosenID == id);
            if (dosen == null)
            {
                return NotFound();
            }

            return View(dosen);
        }

        // POST: Dosen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dosen = await _context.Dosen.FindAsync(id);
            if (dosen == null)
            {
                return NotFound();
            }

            _context.Dosen.Remove(dosen);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Data deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}