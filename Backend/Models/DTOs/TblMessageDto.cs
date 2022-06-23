namespace Dissociate.Models
{
    public class TblMessageDto
    {
        public TblMessageDto(TblMessage message)
        {
            MessageId = message.IdMessage;
            IdReceiveUser = message.IdReceiveUser;
            IdSendUser = message.IdSendUser;
            MessageContent = message.MessageContent;
            SendTime = message.SendTime ?? DateTime.Now;
        }
        public int MessageId { get; set; }
        public int IdReceiveUser { get; set; }
        public int IdSendUser { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendTime { get; set; }
    }
}