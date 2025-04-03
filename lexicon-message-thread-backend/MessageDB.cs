namespace lexicon_message_thread_backend;
using Microsoft.EntityFrameworkCore;


public class MessageDB : DbContext
{
    public MessageDB(DbContextOptions<MessageDB> options) : base(options) { }

    public DbSet<HttpModels.Message> Messages => Set<HttpModels.Message>();

}

