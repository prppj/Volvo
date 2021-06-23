using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvo.Data;
using Volvo.Models;

namespace Volvo.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly VolvoContext _context;
        private List<SelectListItem> modelos;

        public CaminhaoController(VolvoContext context)
        {
            modelos = new List<SelectListItem>
            {
                new SelectListItem {Text = "FM", Value = "FM"},
                new SelectListItem {Text = "FH", Value = "FH"},
                new SelectListItem {Text = "M0", Value = "M0"},
                new SelectListItem {Text = "M1", Value = "M1"}
            };

            _context = context;
        }

        // GET: Caminhaos
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Caminhoes.ToListAsync());
        }

        // GET: Caminhaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .FirstOrDefaultAsync(m => m.CaminhaoID == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhaos/Create
        public IActionResult Create()
        {
            ViewBag.Modelos = this.modelos;

            return View();
        }

        // POST: Caminhaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaminhaoID,Modelo,AnoFabricacao,AnoModelo,Cor,NroEixos")] Caminhao caminhao)
        {            
            if (ModelState.IsValid)
            {                                
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Modelos = this.modelos;
            return View(caminhao);
        }

        // GET: Caminhaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Modelos = this.modelos;

            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes.FindAsync(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return View(caminhao);
        }

        // POST: Caminhaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaminhaoID,Modelo,AnoFabricacao,AnoModelo,Cor,NroEixos")] Caminhao caminhao)
        {
            ViewBag.Modelos = this.modelos;

            if (id != caminhao.CaminhaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.CaminhaoID))
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
            return View(caminhao);
        }

        // GET: Caminhaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .FirstOrDefaultAsync(m => m.CaminhaoID == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhao = await _context.Caminhoes.FindAsync(id);
            _context.Caminhoes.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhoes.Any(e => e.CaminhaoID == id);
        }



    }
}
