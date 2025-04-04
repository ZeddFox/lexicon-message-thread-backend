using Microsoft.EntityFrameworkCore;
namespace lexicon_message_thread_backend
{
    public class MessageDB : DbContext
    {
        public MessageDB(DbContextOptions<MessageDB> options) : base(options) { }

        public DbSet<HttpModels.Message> Messages { get; set; }

    }
}

