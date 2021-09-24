using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications.Users;
using TheSurvey.Entities;
using TheSurvey.Services;
using TheSurvey.Services.Users;

namespace TheSurvey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Register(string login, string password, string firstName, string lastName, string surName)
        {
            UserRegisterDto registerRequest = new UserRegisterDto()
            {
                Login = login,
                HashPassword = PasswordHasher.GetHash(password),
            };

            try
            {
                await _usersService.Register(registerRequest);
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
            try
            {
                var identity = await GetIdentity(login, password);
                if (identity == null)
                {
                    return BadRequest(new { errorText = "Invalid username or password." });
                }


                var response = JWT.Create(identity);

                return Ok(response);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCurrent()
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }
                var user = await _usersService.GetUser(new GetUserByIdSpecification(new Guid(id)));
                return Ok(user);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //[Authorize]
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetTasks()
        //{
        //    try
        //    {
        //        var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();

        //        var result = await _usersService.GetTasks(new GetUserByIdSpecification(new Guid(id)));
        //        return Ok(result);
        //    }
        //    catch (Exception err)
        //    {
        //        return BadRequest(err.Message);
        //    }
        //}

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePassword(string oldPassword, string newPassword, string newPasswordConfirmation)
        {
            try
            {
                var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                if (String.IsNullOrEmpty(id))
                {
                    return Unauthorized();
                }
                await _usersService.UpdatePassword(new GetUserByIdSpecification(new Guid(id)), oldPassword, newPassword, newPasswordConfirmation, new Guid(id));
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //[Authorize]
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> UpdateBIO()
        //{
        //    var id = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
        //    if (String.IsNullOrEmpty(id))
        //    {
        //        return Unauthorized();
        //    }

        //    using (var reader = new StreamReader(Request.Body))
        //    {
        //        var body = await reader.ReadToEndAsync();

        //        try
        //        {
        //            UserBIODto userBio = JsonSerializer.Deserialize<UserBIODto>(body);

        //            await _usersService.Update(new GetUserByIdSpecification(new Guid(id)), u => , createdById);

        //            return Ok();
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.Message);
        //        }
        //    }
        //}

        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            UserDto person = await _usersService.GetUser(new GetUserByLoginPassSpecification(login, PasswordHasher.GetHash(password)));
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "User"),
                    new Claim("Id", person.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
