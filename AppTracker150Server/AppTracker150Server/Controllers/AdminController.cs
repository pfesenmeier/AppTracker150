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
    public class AdminController : ApiController
    {
        public IHttpActionResult GetProfile(Guid id)
        {
            StudentService studentService = CreateStudentService();
            var profile = studentService.GetStudentById(id);
            return Ok(profile);
        }

        public IHttpActionResult GetApplications()
        {
            var ApplicationService = CreateApplicationService();
            var application = GetApplications();
            return Ok(application);

        }

        public IHttpActionResult GetApplicationById(int id)
        {
            var ApplicationService = CreateApplicationService();
            var application = ApplicationService.GetApplicationById(id);
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
