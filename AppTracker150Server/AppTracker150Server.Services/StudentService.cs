using AppTracker150Server.Data;
using AppTracker150Server.Models;
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
                    StudentId = model.StudentId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CohortId = model.CohortId,
                    ResumeLink = model.ResumeLink,
                    LinkedInLink = model.LinkedInLink,
                    PortfolioLink = model.PortfolioLink,
                    GitHub = model.GitHub,
                };
            using ( var context = new ApplicationDbContext())
            {
                context.Student.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<StudentListItem>GetStudents()
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Student
                    .Select(
                    e => new StudentListItem()
                    {
                        StudentId = e.StudentId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        CohortId = e.CohortId,
                        ResumeLink = e.ResumeLink,
                        LinkedInLink = e.LinkedInLink,
                        PortfolioLink = e.PortfolioLink,
                        GitHub = e.GitHub,

                    });
                return entity.ToArray();

            }
        }
        public StudentDetail GetStudentById (Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Student.Single(e => e.StudentId == id);
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
