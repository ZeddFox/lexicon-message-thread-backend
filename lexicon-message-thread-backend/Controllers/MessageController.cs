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
            var messages = _messageDB.Messages.ToList();
            int currentID = 0;

            foreach (var item in messages)
            {
                if (currentID < item.MessageID)
                {
                    currentID = item.MessageID;
                }
            }

            currentID++;

            message.MessageID = currentID;
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
            catch(Exception ex)
            {
                return Results.Conflict(ex.ToString());
            }
        }
    }
}
