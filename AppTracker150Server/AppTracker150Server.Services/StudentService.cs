using AppTracker150Server.Data;
using AppTracker150Server.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    StudentId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CohortId = model.CohortId,
                    ResumeLink = model.ResumeLink,
                    LinkedInLink = model.LinkedInLink,
                    PortfolioLink = model.PortfolioLink,
                    GitHub = model.GitHub
                };
            using ( var context = new ApplicationDbContext())
            {
                context.Student.Add(entity);
                return context.SaveChanges() == 1;
            }
        }


        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var context = new ApplicationDbContext())
            {
                string roleId = context
                                    .Roles
                                    .Where(r => r.Name == "Student")
                                    .First()
                                    .Id;
                
                var leftOuterJoinQuery =
                    from user in context.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId))
                    join profile in context.Student on user.Id equals profile.StudentId.ToString() into userProfile
                    from item in userProfile.DefaultIfEmpty()
                    select new StudentListItem()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = user.UserName,
                        StudentId = user.Id
                    };

                return leftOuterJoinQuery.ToList();
            }
        }

        public UserInfo GetUserById(Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var _id = id.ToString();
                var entity = context.Users.Single(u => u.Id == _id);
                return new UserInfo()
                {
                    Id = Guid.Parse(entity.Id),
                    UserName = entity.UserName
                };

            }
        }

        public StudentDetail GetStudentById (Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Student.SingleOrDefault(e => e.StudentId == id);
                if (entity != null)
                {
                    return
                        new StudentDetail
                        {
                            StudentId = entity.StudentId,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            CohortId = entity.CohortId,
                            ResumeLink = entity.ResumeLink,
                            LinkedInLink = entity.LinkedInLink,
                            PortfolioLink = entity.PortfolioLink,
                            GitHub = entity.GitHub,
                        };
                }
                else
                {
                    return null;
                }

            }
        }

        public StudentFullDetail GetFullStudentInfoById(Guid id)
        {
            using (var context = new ApplicationDbContext()) 
            {
                var student = context.Student.SingleOrDefault(e => e.StudentId == id);
                var cohort = context.Cohorts.SingleOrDefault(c => SqlFunctions.StringConvert((double?)c.Id).Trim() == student.CohortId);
                var applications = context.Applications.Where(a => a.StudentId == id).Select(a =>
                    new ApplicationListItem()
                    {
                        ApplicationId = a.Id,
                        PositionName = a.PositionName,
                        CompanyName = a.CompanyName,
                        ApplicationStatus = a.ApplicationStatus.ToString(),
                        DateCreatedUtc = a.DateCreatedUtc
                    }
                    ).ToList();
                StudentFullDetail profile = null;
                if (student != null)
                {
                    profile =
                        new StudentFullDetail
                        {
                            StudentId = student.StudentId,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            ResumeLink = student.ResumeLink,
                            LinkedInLink = student.LinkedInLink,
                            PortfolioLink = student.PortfolioLink,
                            GitHub = student.GitHub, 
                            Applications = applications
                        };
                }
                else
                {
                    return null;
                }
                if(cohort != null)
                {
                    profile.Cohort = new CohortListItem() 
                    {
                        Course = cohort.Course.ToString(),
                        EndDateUtc = cohort.EndDateUtc,
                        FullTime = cohort.FullTime,
                        Id = cohort.Id
                    };
                    profile.FullOrPartTime = cohort.FullTime ? "FullTime" : "PartTime";
                }
                return profile;
            }
        }
        public bool UpdateStudent(StudentEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Student.Single(e => e.StudentId == model.StudentId);

                entity.StudentId = model.StudentId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.CohortId = model.CohortId;
                entity.ResumeLink = model.ResumeLink;
                entity.LinkedInLink = model.LinkedInLink;
                entity.PortfolioLink = model.PortfolioLink;
                entity.GitHub = model.GitHub;

                return context.SaveChanges() == 1;

            };
        }

        public bool DeleteStudent(Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var _id = id.ToString();
                var entity = context.Users.Single(e => e.Id == _id);
                context.Users.Remove(entity);

                return context.SaveChanges() == 1;
            }
        }





    }
}
