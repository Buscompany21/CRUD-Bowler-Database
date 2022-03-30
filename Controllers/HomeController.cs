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

        //The following two routes are for the form to add a bowler
        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBowler(b);
                _repo.SaveBowler(b);

                return View("Index", b);
            }
            else
            {
                return View(b);
            }

        }

        //The following is for editing a bowlers information
        [HttpGet]
        public IActionResult Edit(int BowlerID)
        {

            var bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveBowler(b);
                return RedirectToAction("Index", b);
            }
            else
            {
                return View(b);
            }    
        }

        //The following is for deleting a bowlers information
        [HttpGet]
        public IActionResult Delete(int BowlerID)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);
            _repo.DeleteBowler(bowler);
            return View("Index");
        }

    }
}
