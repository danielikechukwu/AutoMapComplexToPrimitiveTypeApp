using AutoMapComplexToPrimitiveType.Data;
using AutoMapComplexToPrimitiveType.DTOs;
using AutoMapComplexToPrimitiveType.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapComplexToPrimitiveType.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserDbContext _context;

        public UsersController(IMapper mapper, UserDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/user/GetUsers
        // Retrieves all users.
        // Maps from complex User (with Address) to UserDTO (with primitive properties).
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            List<User> users = await _context.Users
                .AsNoTracking()
                .Include(u => u.Address)
                .ToListAsync();

            if (users == null || users.Count == 0)
                return NotFound("No user found");

            var userDTOs = _mapper.Map<List<UserDTO>>(users);

            return Ok(userDTOs);
        }


        // GET: api/user/GetUserById/{id}
        // Retrieves a specific user by ID.
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users
                 .AsNoTracking()
                 .Include(u => u.Address)
                 .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
                return NotFound($"User with ID {id} not found");

            var userDTO = _mapper.Map<UserDTO>(user);

            return Ok(userDTO);

        }

        // POST: api/user/CreateUser
        // Creates a new user.
        // Maps from UserCreateDTO (primitive properties) to User (with a complex Address).
        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            User user = _mapper.Map<User>(userCreateDTO);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var userDTO = _mapper.Map<UserDTO>(user);

            return Ok(userDTO);

        }
    }
}
