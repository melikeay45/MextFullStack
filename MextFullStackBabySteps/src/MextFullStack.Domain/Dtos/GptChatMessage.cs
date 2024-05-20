using MextFullStack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStack.Domain.Dtos
{
    public class GptChatMessage
    {
        public GptChatMessageType MessageType { get; set; }
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public GptChatMessage(string message, GptChatMessageType messageType)
        {
            Message = message;

            MessageType = messageType;

            CreatedOn = DateTime.Now;
        }

        public GptChatMessage()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
