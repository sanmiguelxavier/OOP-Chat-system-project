using System;

namespace ChatV2
{
    public class Message
    {
        public string MessageId { get; set; } 
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; } // Timestamp 

        public Message()
        {
            MessageId = Guid.NewGuid().ToString(); 
        }
    }
}
