using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return _context.Tickets != null ?
                        View(await _context.Tickets.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Tickets'  is null.");
        }

        // GET: Tickets/AddOrEdit
        public async Task<IActionResult> AddOrEdit(int? id = 0)
        {
            ViewBag.Status = new List<TicketStatus>() { TicketStatus.Open, TicketStatus.Closed, TicketStatus.Fixed, TicketStatus.NotGoingToFix };
            if (id == 0)
            {
                return View(new Tickets());
            }
            else
            {
                var tickets = await _context.Tickets.FindAsync(id);
                if (tickets == null)
                {
                    return NotFound();
                }
                return View(tickets);
            }
        }



        // POST: Tickets/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Status,Subject,WorkDescription,Date")] Tickets tickets)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(tickets);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "";
                }

                else
                {
                    try
                    {
                        _context.Update(tickets);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TicketsExists(tickets.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Tickets.ToList())});
              }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", tickets) });
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var tickets = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tickets'  is null.");
            }
            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets != null)
            {
                _context.Tickets.Remove(tickets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketsExists(int id)
        {
            return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}