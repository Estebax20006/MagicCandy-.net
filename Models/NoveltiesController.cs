using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MagicCandy.Models
{
    public class NoveltiesController : Controller
    {
        private readonly MagicandyContext _context;

        public NoveltiesController(MagicandyContext context)
        {
            _context = context;
        }

        // GET: Novelties
        public async Task<IActionResult> Index()
        {
            var magicandyContext = _context.Novelties.Include(n => n.FkNoveltyStates).Include(n => n.FkProductions).Include(n => n.FkReferred).Include(n => n.FkSenders);
            return View(await magicandyContext.ToListAsync());
        }

        // GET: Novelties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novelty = await _context.Novelties
                .Include(n => n.FkNoveltyStates)
                .Include(n => n.FkProductions)
                .Include(n => n.FkReferred)
                .Include(n => n.FkSenders)
                .FirstOrDefaultAsync(m => m.Pkid == id);
            if (novelty == null)
            {
                return NotFound();
            }

            return View(novelty);
        }

        // GET: Novelties/Create
        public IActionResult Create()
        {
            ViewData["FkNoveltyStatesId"] = new SelectList(_context.NoveltyStatuses, "Pkid", "Pkid");
            ViewData["FkProductionsId"] = new SelectList(_context.Productions, "Pkid", "Pkid");
            ViewData["FkReferredId"] = new SelectList(_context.Referrals, "Pkid", "Pkid");
            ViewData["FkSendersId"] = new SelectList(_context.Senders, "Pkid", "Pkid");
            return View();
        }

        // POST: Novelties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,FkNoveltyStatesId,FkProductionsId,FkReferredId,FkSendersId,Pkid,Time,Subject,Comment")] Novelty novelty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novelty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkNoveltyStatesId"] = new SelectList(_context.NoveltyStatuses, "Pkid", "Pkid", novelty.FkNoveltyStatesId);
            ViewData["FkProductionsId"] = new SelectList(_context.Productions, "Pkid", "Pkid", novelty.FkProductionsId);
            ViewData["FkReferredId"] = new SelectList(_context.Referrals, "Pkid", "Pkid", novelty.FkReferredId);
            ViewData["FkSendersId"] = new SelectList(_context.Senders, "Pkid", "Pkid", novelty.FkSendersId);
            return View(novelty);
        }

        // GET: Novelties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novelty = await _context.Novelties.FindAsync(id);
            if (novelty == null)
            {
                return NotFound();
            }
            ViewData["FkNoveltyStatesId"] = new SelectList(_context.NoveltyStatuses, "Pkid", "Pkid", novelty.FkNoveltyStatesId);
            ViewData["FkProductionsId"] = new SelectList(_context.Productions, "Pkid", "Pkid", novelty.FkProductionsId);
            ViewData["FkReferredId"] = new SelectList(_context.Referrals, "Pkid", "Pkid", novelty.FkReferredId);
            ViewData["FkSendersId"] = new SelectList(_context.Senders, "Pkid", "Pkid", novelty.FkSendersId);
            return View(novelty);
        }

        // POST: Novelties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Date,FkNoveltyStatesId,FkProductionsId,FkReferredId,FkSendersId,Pkid,Time,Subject,Comment")] Novelty novelty)
        {
            if (id != novelty.Pkid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novelty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoveltyExists(novelty.Pkid))
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
            ViewData["FkNoveltyStatesId"] = new SelectList(_context.NoveltyStatuses, "Pkid", "Pkid", novelty.FkNoveltyStatesId);
            ViewData["FkProductionsId"] = new SelectList(_context.Productions, "Pkid", "Pkid", novelty.FkProductionsId);
            ViewData["FkReferredId"] = new SelectList(_context.Referrals, "Pkid", "Pkid", novelty.FkReferredId);
            ViewData["FkSendersId"] = new SelectList(_context.Senders, "Pkid", "Pkid", novelty.FkSendersId);
            return View(novelty);
        }

        // GET: Novelties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novelty = await _context.Novelties
                .Include(n => n.FkNoveltyStates)
                .Include(n => n.FkProductions)
                .Include(n => n.FkReferred)
                .Include(n => n.FkSenders)
                .FirstOrDefaultAsync(m => m.Pkid == id);
            if (novelty == null)
            {
                return NotFound();
            }

            return View(novelty);
        }

        // POST: Novelties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novelty = await _context.Novelties.FindAsync(id);
            if (novelty != null)
            {
                _context.Novelties.Remove(novelty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoveltyExists(int id)
        {
            return _context.Novelties.Any(e => e.Pkid == id);
        }
    }
}
