using Housematica.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Single = Housematica.Data.Data.CMS.Single;
namespace Housematica.NewWWW.Services
{
    public class ShowreelForView
    {
        private readonly HousematicaContext _context;
        private string showreelId { get; set; }
        public ShowreelForView(string id, HousematicaContext context)
        {
            showreelId = id;
            _context = context;
        }

        public Single GetData()
        {
            return (_context.Single.Where(x => x.SingleGuid.ToString().Contains(showreelId)).Include(x => x.Projects).ThenInclude(x => x.ProjectType).Include(x => x.SingleFloor).ThenInclude(x => x.SingleRooms).FirstOrDefault());
        }
    }
}
