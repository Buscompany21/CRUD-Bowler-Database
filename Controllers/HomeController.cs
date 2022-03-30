using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        //Constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            var blah = _repo.Bowlers
                //.Include(x => teams)
                //.FromSqlRaw("SELECT * FROM Recipes WHERE RecipeTitle Like 'a%'")
                .Where(p => p.Team.TeamName == teamName || teamName == null)
                .ToList();

            return View(blah);
        }
    }
}
