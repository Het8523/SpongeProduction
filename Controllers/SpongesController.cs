using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpongeProduction.Data;
using SpongeProduction.Models;


namespace SpongeProduction.Controllers
{
    public class SpongesController : Controller
    {
        private readonly SpongeProductionContext _context;

        public SpongesController(SpongeProductionContext context)
        {
            _context = context;
        }

        // GET: Sponges
        public async Task<IActionResult> Index(string spongeShape, string searchString)
        {
            IQueryable<string> shapeQuery = from m in _context.Sponge
                                            orderby m.Shape
                                            select m.Shape;

            var sponges = from m in _context.Sponge
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                sponges = sponges.Where(s => s.Company.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(spongeShape))
            {
                sponges = sponges.Where(x => x.Shape == spongeShape);
            }

            var SpongeShapeVM = new SpongeShapeViewModel
            {
                Shapes = new SelectList(await shapeQuery.Distinct().ToListAsync()),
                Sponges = await sponges.ToListAsync()
            };

            return View(SpongeShapeVM);
        }


        // GET: Sponges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponge = await _context.Sponge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponge == null)
            {
                return NotFound();
            }

            return View(sponge);
        }

        // GET: Sponges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sponges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,Colour,Shape,Price,ReleaseDate")] Sponge sponge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponge);
        }

        // GET: Sponges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponge = await _context.Sponge.FindAsync(id);
            if (sponge == null)
            {
                return NotFound();
            }
            return View(sponge);
        }

        // POST: Sponges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,Colour,Shape,Price,ReleaseDate")] Sponge sponge)
        {
            if (id != sponge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpongeExists(sponge.Id))
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
            return View(sponge);
        }

        // GET: Sponges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponge = await _context.Sponge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponge == null)
            {
                return NotFound();
            }

            return View(sponge);
        }

        // POST: Sponges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponge = await _context.Sponge.FindAsync(id);
            _context.Sponge.Remove(sponge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpongeExists(int id)
        {
            return _context.Sponge.Any(e => e.Id == id);
        }
    }
}
