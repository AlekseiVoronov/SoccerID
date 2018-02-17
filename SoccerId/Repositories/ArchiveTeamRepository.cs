using SoccerId.Entities;
using SoccerId.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoccerId.Repositories
{
    public class ArchiveTeamRepository : BaseRepository<ArchiveTeam>
    {
        public override ArchiveTeam GetById(int id)
        {
            ArchiveTeam result = null;
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                result = context.ArchiveTeams.Where(t => t.Id == id).FirstOrDefault();
            }
            return result;
        }

        public override async Task<ArchiveTeam> GetByIdAsync(int id)
        {

            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                return await Task<ArchiveTeam>.Factory.StartNew(() =>
                {
                    return context.ArchiveTeams.Where(t => t.Id == id).FirstOrDefault();
                });
            }

        }

        public override void Remove(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var archiveTeam = context.ArchiveTeams.FirstOrDefault(t => t.Id == id);
                context.Entry(archiveTeam).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override async Task RemoveAsync(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var archiveTeam = context.ArchiveTeams.FirstOrDefault(t => t.Id == id);
                context.Entry(archiveTeam).State = System.Data.Entity.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}