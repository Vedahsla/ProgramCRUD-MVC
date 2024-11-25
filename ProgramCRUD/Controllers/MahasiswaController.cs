using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramCRUD.Services;
using ProgramCRUD.Models;

namespace ProgramCRUD.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MahasiswaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mahasiswa
        public async Task<IActionResult> Index()
        {
            var listdata = await _context.tblMahasiswa.ToListAsync();

            //return View(await _context.tblMahasiswa.ToListAsync());
            return View(listdata);
        }

        // GET: Mahasiswa/Create

        public IActionResult Create()
        {
            // var model = new GenderList();
            // model.Gender = getGenderList();
            return View();
        }

        // POST: Mahasiswa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NIM,Name,Gender,Telephone,Address,Join_Date,Graduation_Date,Dosen_Wali,Fakultas_Code,Department_Code")] Mahasiswa mahasiswa)
        {
            if (mahasiswa.Gender == "0")
            {
                // ModelState.AddModelError("Gender", "Please select gender!");
                // TempData["Message"] = "Please select gender!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(mahasiswa);
                    await _context.SaveChangesAsync();

                    TempData["AlertMessage"] = "Data created successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.tblMahasiswa.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswa/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NIM,Name,Gender,Telephone,Address,Join_Date,Graduation_Date,Dosen_Wali,Fakultas_Code,Department_Code")] Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahasiswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.tblMahasiswa.Any(e => e.ID == mahasiswa.ID))
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
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.tblMahasiswa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswa/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mahasiswa = await _context.tblMahasiswa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswa/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mahasiswa = await _context.tblMahasiswa.FindAsync(id);

            if (mahasiswa == null)
            {
                return NotFound();
            }
            _context.tblMahasiswa.Remove(mahasiswa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}