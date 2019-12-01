﻿using AppTracker150Server.Data;
using AppTracker150Server.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
                        StudentId = item.StudentId
                    };

                return leftOuterJoinQuery.ToList();
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

        public bool DeleteStudent(Guid Id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Student.Single(e => e.StudentId == Id);
                context.Student.Remove(entity);

                return context.SaveChanges() == 1;
            }
        }





    }
}
