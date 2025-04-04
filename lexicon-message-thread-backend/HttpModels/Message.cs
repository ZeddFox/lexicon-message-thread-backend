using System.ComponentModel.DataAnnotations;
namespace lexicon_message_thread_backend.HttpModels
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public DateTime? SendDate { get; set; } = DateTime.Now;
        public string MessageString { get; set; }

    }
}
