using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReastApiJwt.Data;
using ReastApiJwt.Models;
using ReastApiJwt.Services;

namespace ReastApiJwt.Models
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model, [FromServices]DataContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = await context.Users.AsNoTracking().Where( x => x.Username == model.Username && x.Password == model.Password).FirstOrDefaultAsync();
                if (user == null)
                    return NotFound(new { message = "Invalid User or Password..."});
                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return new {
                    user = user,
                    token = token
                }; 
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Could not authenticate. Error: {ex.Message}"});
            }
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Post([FromBody]User model, [FromServices]DataContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == model.Username);
                if(user != null)
                    return BadRequest(new { message = $"Could not create User with that username"});
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return Ok(new { message = $"User {model.Username} created"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Could not create User. Error: {ex.Message}"});
            }
        }
        
    }
}

