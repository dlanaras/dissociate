using Dissociate.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Dissociate.Contexts;
using Microsoft.AspNetCore.Cors;

namespace Dissociate.Controllers
{

    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DissociateController : ControllerBase
    {
        private readonly DissociateContext _context;

        public DissociateController(DissociateContext context)
        {
            _context = context;
        }

        private bool HasSession()
        {
            return HttpContext.Session.TryGetValue("UserId", out _);
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginCreds loginCreds)
        {
            if(!HasSession())
            {
                var user = _context.Accounts.FirstOrDefault(a => a.Email.Equals(loginCreds.Email) && a.Password.Equals(loginCreds.Password));
                if(user != null)
                {
                    HttpContext.Session.SetString("UserId", user.UserName);
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public ActionResult<List<Account>> Test()
        {
            return _context.Accounts.ToList();
        }
    }
}