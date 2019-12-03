using AppTracker150Server.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppTracker150Server.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("Admin")]
    public class AdminController : ApiController
    {
        [Route("Students")]
        public IHttpActionResult GetStudents()
        {
            StudentService studentService = CreateStudentService();
            var students = studentService.GetStudents();
            return Ok(students);
        }

        [Route("Students")]
        public IHttpActionResult GetProfile(Guid id)
        {
            StudentService studentService = CreateStudentService();
            var profile = studentService.GetFullStudentInfoById(id);
            return Ok(profile);
        }
        [Route("Applications")]
        public IHttpActionResult GetApplications()
        {
            var ApplicationService = CreateApplicationService();
            var application = ApplicationService.GetApplications();
            return Ok(application);

        }
        [Route("Applications")]
        public IHttpActionResult GetApplicationById(int id, Guid studentId)
        {
            var ApplicationService = CreateApplicationService();
            var application = ApplicationService.GetApplicationById(id, studentId);
            return Ok(application);
        }


        private ApplicationService CreateApplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var applicationService = new ApplicationService(userId);
            return applicationService;

        }



        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            return studentService;

        }
    }
}
