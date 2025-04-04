using lexicon_message_thread_backend.HttpModels;
using Microsoft.AspNetCore.Mvc;

namespace lexicon_message_thread_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController(MessageDB messageDB) : Controller
    {
        private readonly MessageDB _messageDB = messageDB;

        [Route("read")]
        [HttpGet]
        public IResult Index()
        {
            return Results.Ok(new
            {
                messages = _messageDB.Messages.ToList()
            });
        }

        [Route("write")]
        [HttpPost]
        public IResult Write(Message message)
        {
            message.MessageID = 5050;
            message.SendDate = DateTime.Now;

            try
            {
                _messageDB.Messages.Add(message);
                _messageDB.SaveChanges();

                return Results.Ok(new
                {
                    status = "Message sent successfully."
                });
            }
            catch
            {
                return Results.Conflict();
            }
        }
    }
}
