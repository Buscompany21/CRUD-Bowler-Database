using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Views.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent (IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var teams = repo.Bowlers
                .Select(x => x.BowlerFirstName) //put the teams here later
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
