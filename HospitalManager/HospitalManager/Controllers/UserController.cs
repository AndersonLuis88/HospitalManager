using HospitalManager.Data;
using HospitalManager.Enums;
using HospitalManager.Models;
using HospitalManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{

    [Route("users")]
    public class UserController: Controller
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post(
            [FromServices] ApplicationDbContext context,
            [FromBody] User newUser)
        {

            try
            {
                context.User.Add(newUser);
                await context.SaveChangesAsync();
                return newUser;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }  

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] ApplicationDbContext context,
            [FromBody] User user)
        {
            var login = await context.User
                .AsNoTracking()
                .Where(x => x.UserName == user.UserName && x.Password == user.Password)
                .FirstOrDefaultAsync();

            if (login == null)
                return NotFound();

            var token = TokenService.GenerateToken(login);
            return new
            {
                user = login,
                token = token
            };
            
        }
    }
}
