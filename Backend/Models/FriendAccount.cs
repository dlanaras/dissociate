using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dissociate.Models
{
    public class FriendAccount
    {
    public int Id { get; set; }

    public int AccountId { get; set; } 
    public virtual Account Account { get; set; }

    public int FriendId { get; set; }
    public virtual Account Friend { get; set; }
    }
}