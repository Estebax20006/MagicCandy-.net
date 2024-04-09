using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MagicCandy.Models
{
    public class ActivitiesController : Controller
    {
        private readonly MagicandyContext _context;

        public ActivitiesController(MagicandyContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var magicandyContext = _context.Activities.Include(a => a.FkActivityManagers).Include(a => a.FkActivityStatuses).Include(a => a.FkProduction);
            return View(await magicandyContext.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.FkActivityManagers)
                .Include(a => a.FkActivityStatuses)
                .Include(a => a.FkProduction)
                .FirstOrDefaultAsync(m => m.Pkid == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["FkActivityManagersId"] = new SelectList(_context.ActivityManagers, "Pkid", "Pkid");
            ViewData["FkActivityStatusesId"] = new SelectList(_context.ActivityStatuses, "Pkid", "Pkid");
            ViewData["FkProductionId"] = new SelectList(_context.Productions, "Pkid", "Pkid");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FkActivityManagersId,FkActivityStatusesId,FkProductionId,Pkid,EndDate,StartDate,Title,Description")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkActivityManagersId"] = new SelectList(_context.ActivityManagers, "Pkid", "Pkid", activity.FkActivityManagersId);
            ViewData["FkActivityStatusesId"] = new SelectList(_context.ActivityStatuses, "Pkid", "Pkid", activity.FkActivityStatusesId);
            ViewData["FkProductionId"] = new SelectList(_context.Productions, "Pkid", "Pkid", activity.FkProductionId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["FkActivityManagersId"] = new SelectList(_context.ActivityManagers, "Pkid", "Pkid", activity.FkActivityManagersId);
            ViewData["FkActivityStatusesId"] = new SelectList(_context.ActivityStatuses, "Pkid", "Pkid", activity.FkActivityStatusesId);
            ViewData["FkProductionId"] = new SelectList(_context.Productions, "Pkid", "Pkid", activity.FkProductionId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FkActivityManagersId,FkActivityStatusesId,FkProductionId,Pkid,EndDate,StartDate,Title,Description")] Activity activity)
        {
            if (id != activity.Pkid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.Pkid))
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
            ViewData["FkActivityManagersId"] = new SelectList(_context.ActivityManagers, "Pkid", "Pkid", activity.FkActivityManagersId);
            ViewData["FkActivityStatusesId"] = new SelectList(_context.ActivityStatuses, "Pkid", "Pkid", activity.FkActivityStatusesId);
            ViewData["FkProductionId"] = new SelectList(_context.Productions, "Pkid", "Pkid", activity.FkProductionId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.FkActivityManagers)
                .Include(a => a.FkActivityStatuses)
                .Include(a => a.FkProduction)
                .FirstOrDefaultAsync(m => m.Pkid == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.Pkid == id);
        }
    }
}
