using System;
using System.Collections.Generic;

namespace Dissociate.Models
{
    public partial class TblMessage
    {
        public int IdMessage { get; set; }
        public int IdReceiveUser { get; set; }
        public int IdSendUser { get; set; }
        public string MessageContent { get; set; }
        public DateTime? SendTime { get; set; }

        public virtual TblUser IdReceiveUserNavigation { get; set; }
        public virtual TblUser IdSendUserNavigation { get; set; }
    }
}
