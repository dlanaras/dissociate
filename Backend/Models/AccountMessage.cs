using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dissociate.Models
{
    public class AccountMessage
    {
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        public Account Account { get; set; }

        [Required]
        public int MessageId { get; set; }

        public Message Message { get; set; }
    }
}