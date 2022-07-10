using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IssueTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult Create()
        {
            var model = _context.TeamMember;

            List<string> names = new List<string>();
            if (model != null)
            {
                foreach (var user in model)
                {
                    names.Add(user.FirstName);
                }
            }
            else { names = new List<string>(); }

            ViewBag.teamMembers = names;

            return View();
        }


        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projects projects)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(projects);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(projects);
        }



        public ActionResult Dashboard()
        {
            ViewBag.title = "Dash Board";

            var model = new DashboardViewModel();

            model.NumberOfTickets = _context.Tickets.Count();
            model.NumberOfTicketsOpen = _context.Tickets.Where(u => u.Status == TicketStatus.Open).Count();
            model.NumberOfTicketsResolved = _context.Tickets.Where(u => u.Status == TicketStatus.Fixed).Count();
            model.NumberOfTicketsRejected = _context.Tickets.Where(u => u.Status == TicketStatus.NotGoingToFix).Count();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}