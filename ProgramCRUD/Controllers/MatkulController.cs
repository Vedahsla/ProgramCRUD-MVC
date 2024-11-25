using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramCRUD.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProgramCRUD.Services;

namespace ProgramCRUD.Controllers
{
    public class MatkulController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatkulController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatkulDosen
        public async Task<IActionResult> Index()
        {
            var matkulList = await _context.Matkul.ToListAsync();
            return View(matkulList);
        }

        // GET: MatkulDosen/Details/1
        public async Task<IActionResult> ListDosen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matkul = await _context.Matkul
                .FirstOrDefaultAsync(m => m.Id == id);

            if (matkul == null)
            {
                return NotFound();
            }

            // Splitting DosenPengampu by commas to create a list
            var dosenList = matkul.DosenPengampu.Split(',')
                                 .Select(d => d.Trim())
                                 .ToList();

            // Using ViewData to pass additional data
            ViewData["KodeMataKuliah"] = matkul.KodeMataKuliah;
            ViewData["NamaMataKuliah"] = matkul.NamaMataKuliah;

            return View(dosenList);
        }
    }
}
