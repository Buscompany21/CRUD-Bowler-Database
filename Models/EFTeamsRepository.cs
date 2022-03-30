using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFTeamsRepository(BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Team> Teams => _context.Teams;
    }
}

