using Dissociate.Models;
using System;
using System.Linq;
using Dissociate.Contexts;

namespace Dissociate
{
    public static class DbSeed
    {
        public static void Initialize(DissociateContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.TblMessages.Any())
            {
                return;   // DB has been seeded
            }

            // Add TblUsers
            var tblUsers = new TblUser[]
            {
                new TblUser {
                     Username = "admin",
                     Password = "admin",
                     Email = "admin@admin.admin"
                    },
                new TblUser {
                     Username = "user",
                     Password = "user",
                     Email = "user@user.user"
                }
            };

            context.TblUsers.AddRange(tblUsers);

            // Add TblMessages
            var tblMessages = new TblMessage[]
            {
                new TblMessage {
                     IdReceiveUser = 1,
                     IdSendUser = 2,
                     MessageContent = "Hello",
                     SendTime = DateTime.Now
                    },
                new TblMessage {
                     IdReceiveUser = 2,
                     IdSendUser = 1,
                     MessageContent = "Hello",
                     SendTime = DateTime.Now.Subtract(TimeSpan.FromDays(10000000))
                }
            };

            context.TblMessages.AddRange(tblMessages);
        }
    }
}