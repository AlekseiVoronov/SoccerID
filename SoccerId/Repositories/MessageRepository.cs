using SoccerId.Entities;
using SoccerId.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SoccerId.Repositories
{
    public class MessageRepository<TClass> : BaseRepository<TClass> where TClass: BaseMessage
    {
        public override TClass GetById(int id)
        {
            TClass result = null;
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                result = context.Set<TClass>().Where(t => t.Id == id).FirstOrDefault();
            }
            return result;
        }

        public override async Task<TClass> GetByIdAsync(int id)
        {

            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                return await Task<TClass>.Factory.StartNew(() =>
                {
                    return context.Set<TClass>().Where(t => t.Id == id).FirstOrDefault();
                });
            }

        }

        public override void Remove(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var message = context.Set<TClass>().FirstOrDefault(t => t.Id == id);
                context.Entry(message).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public override async Task RemoveAsync(int id)
        {
            using (SoccerIdDBContext context = new SoccerIdDBContext())
            {
                var message = context.Set<TClass>().FirstOrDefault(t => t.Id == id);
                context.Entry(message).State = System.Data.Entity.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }

    public class ChatMessageRepository : BaseRepository<ChatMessage> { }
    public class PrivateMessageRepository : BaseRepository<PrivateMessage> { }
}