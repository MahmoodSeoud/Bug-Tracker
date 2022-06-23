using IssueTracker.Data;
using IssueTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.teamMembers = new List<TeamMember>() { new TeamMember("Mahmood")};  
            return View();
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