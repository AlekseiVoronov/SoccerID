using SoccerId.Entities;
using SoccerId.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoccerId.Repositories
{
    public class EventPlaceRepository : BaseRepository<EventPlace>
    {
        public override EventPlace GetById(int id)
        {
            EventPlace result = null;
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                result = context.EventPlaces.Where(t => t.Id == id).FirstOrDefault();
            }
            return result;
        }

        public override async Task<EventPlace> GetByIdAsync(int id)
        {

            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                return await Task<EventPlace>.Factory.StartNew(() =>
                {
                    return context.EventPlaces.Where(t => t.Id == id).FirstOrDefault();
                });
            }

        }

        public override void Remove(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var eventPlace = context.EventPlaces.FirstOrDefault(t => t.Id == id);
                context.Entry(eventPlace).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override async Task RemoveAsync(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var eventPlace = context.EventPlaces.FirstOrDefault(t => t.Id == id);
                context.Entry(eventPlace).State = System.Data.Entity.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}