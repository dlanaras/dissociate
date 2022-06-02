using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dissociate.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }

        public ICollection<AccountMessage> AccountMessages { get; set; }

        public ICollection<Account> Friends { get; set; }

    }
}