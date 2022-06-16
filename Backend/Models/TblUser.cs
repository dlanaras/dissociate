using System;
using System.Collections.Generic;

namespace Dissociate.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblMessageIdReceiveUserNavigations = new HashSet<TblMessage>();
            TblMessageIdSendUserNavigations = new HashSet<TblMessage>();
            IdFriends = new HashSet<TblUser>();
            IdUsers = new HashSet<TblUser>();
        }

        public int IdUser { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TblMessage> TblMessageIdReceiveUserNavigations { get; set; }
        public virtual ICollection<TblMessage> TblMessageIdSendUserNavigations { get; set; }

        public virtual ICollection<TblUser> IdFriends { get; set; }
        public virtual ICollection<TblUser> IdUsers { get; set; }
    }
}
