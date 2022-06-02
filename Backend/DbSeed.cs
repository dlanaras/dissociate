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
            if (context.Accounts.Any())
            {
                return;   // DB has been seeded
            }

            /*var students = new Student[]
            {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
            new Course{CourseID=1045,Title="Calculus",Credits=4},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4},
            new Course{CourseID=2021,Title="Composition",Credits=3},
            new Course{CourseID=2042,Title="Literature",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();*/
            /*

                        var accountAdmin = new Account
                        {
                            UserName = "admin",
                            Password = new byte[4] { 0x00, 0x00, 0x00, 0x00 },
                            Email = "admin@admin"
                        };


                        var accountTest = new Account
                        {
                            UserName = "test",
                            Password = new byte[4] { 0x00, 0x00, 0x00, 0x00 },
                            Email = "test@test"
                        };

                        var friendAccountsAdmin = new List<FriendAccount>()
                        {
                            new FriendAccount
                            {
                                Account = accountAdmin,
                                Friend = accountTest
                            },
                            new FriendAccount
                            {
                                Account = accountTest,
                                Friend = accountAdmin
                            }
                        };

                        var friendAccountsTest = new List<FriendAccount>()
                        {
                            new FriendAccount
                            {
                                Account = accountTest,
                                Friend = accountAdmin
                            },
                            new FriendAccount
                            {
                                Account = accountAdmin,
                                Friend = accountTest
                            }
                        };

                        accountTest.Friends = friendAccountsTest;
                        accountTest.Accounts = friendAccountsTest;

                        accountAdmin.Friends = friendAccountsAdmin;
                        accountAdmin.Accounts = friendAccountsAdmin;

                        context.Accounts.Add(accountTest);
                        context.Accounts.Add(accountAdmin);*/

            context.SaveChanges();


            context.Messages.Add(new Message
            {
                Content = "Hello, planet!",
                Date = DateTime.Now
            });

            context.SaveChanges();

            context.AccountMessages.Add(new AccountMessage
            {
                Account = context.Accounts.First(),
                Message = context.Messages.First()
            });

            context.SaveChanges();
        }
    }
}