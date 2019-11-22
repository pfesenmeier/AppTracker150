using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using AppTracker150Server.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppTracker150Server.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        public IHttpActionResult GetGreeting()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                string response;
                if (isAdminUser())
                {
                    response = "Hello Admin";
                }
                else
                {
                    response = "Hello Student";
                }
                return Ok(response);
            }
            return BadRequest();
        }
        public IHttpActionResult Post()
        {
            return Ok();
        }

        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
    
}
