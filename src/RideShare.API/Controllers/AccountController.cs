using Microsoft.AspNetCore.Mvc;
using RideShare.BLL.Dtos.Account;
using RideShare.BLL.Interfaces;

namespace RideShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountService _accountService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto entity)
        {
            if (entity == null)
                return BadRequest("Invalid request");

            try
            {
                await _accountService.RegisterUserAsync(entity);

                return Ok(new { Message = "User registered successfully" });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch
            {
                return BadRequest(new { Message = $"An error occured on the server, please try later" });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto entity)
        {
            if (entity == null)
                return BadRequest("Invalid request");

            try
            {
                var token = await _accountService.LoginUserAsync(entity);

                return Ok(new { token.Token, token.RefreshToken });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch
            {
                return BadRequest(new { Message = $"An error occured on the server, please try later" });
            }
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            return Ok(new { Token = string.Empty, RefreshToken = string.Empty });
        }
    }
}
