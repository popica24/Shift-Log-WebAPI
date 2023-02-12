using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftLogger.Models;
using ShiftLoggerAPI.Tools;
namespace ShiftLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get() =>
            await _context.Users.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = _context.Users.FindAsync(id);
            return await user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if(_context.Users.Where(x=>x.Username==userModel.Username)==null)
                return BadRequest("Username Exists");
            await _context.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = userModel.UserModelId }, userModel);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null) return NotFound();
            _context.Users.Remove(userToDelete);
             await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UserModel userModel)
        {
            if (id != userModel.UserModelId) return BadRequest();

            _context.Entry(userModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            String password = Password.Encrypt(user.Password);
            var dbUser = _context.Users.Where(x => (x.Username == user.Username && x.Password == user.Password)).FirstOrDefault();
            if(dbUser == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(dbUser);
            
        }

    }
}
