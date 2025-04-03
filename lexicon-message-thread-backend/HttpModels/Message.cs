namespace lexicon_message_thread_backend.HttpModels
{
    public class Message
    {
        public int MessageID { get; set; }
        public int UserID { get; set; }
        public DateTime SendDate { get; set; }
        public string MessageString { get; set; }

    }
}
