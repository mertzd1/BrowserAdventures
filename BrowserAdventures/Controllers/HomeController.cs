using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BrowserAdventures.Models;
using BrowserAdventures;
using browsersqlserver.database.windows;

namespace BrowserAdventures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BrowserAdventureContext _context;

        public HomeController(ILogger<HomeController> logger, BrowserAdventureContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login(User user)
        {
            User verifiedUser = _context.User.Where(u => u.Name == user.Name).FirstOrDefault();
            if (verifiedUser == null)
            {
                user.Health = 30;
                user.Level = 1;
                user.Experience = 0;
                user.Screen = 1;
                _context.User.Add(user);
                
                _context.SaveChanges();
                verifiedUser = _context.User.Where(u => u.Name == user.Name).FirstOrDefault();
                _context.FightLogs.Add(new FightLog { UserID = verifiedUser.UserID, Entry = $"{verifiedUser.Name} steps into the world." });
                _context.SaveChanges();
            }
            ConsoleViewModel model = new ConsoleViewModel { User = verifiedUser,
                                                            Log = _context.FightLogs.Where(l => l.UserID == verifiedUser.UserID).ToList(),
                                                            Screen = _context.Screen.Where(s => s.ScreenID == verifiedUser.Screen).FirstOrDefault()};
            return View("Console", model);
        }
    }
}
