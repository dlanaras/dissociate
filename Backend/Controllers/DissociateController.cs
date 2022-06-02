using Dissociate.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Dissociate.Contexts;

namespace Dissociate.Controllers
{
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

        /*[HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCreds loginCreds)
        {
            if(!HasSession())
            {
                var user = {UserName = "test"}; //await _context.Accounts.FirstOrDefaultAsync(a => a.Email == loginCreds.Email && a.Password == loginCreds.Password);
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
        }*/
    }
}