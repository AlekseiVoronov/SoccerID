using SoccerId.Entities;
using SoccerId.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace SoccerId.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository()
        {

        }      

        public override void Remove(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Id == id);
                context.Entry(team).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override async Task RemoveAsync(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Id == id);
                context.Entry(team).State = System.Data.Entity.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }     

        public override Team GetById(int id)
        {
            Team result = null;
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                result = context.Teams.Where(t => t.Id == id).FirstOrDefault();
            }
            return result;
        }

        public override async Task<Team> GetByIdAsync(int id)
        {
            Team result = null;
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                result = await context.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
            }
            return result;
        }
        
    }
}