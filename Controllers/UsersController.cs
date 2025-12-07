using Microsoft.AspNetCore.Mvc;
using UserManagementApiDotNet.Models;

namespace UserManagementApiDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory store of users. In a real application this would be replaced
        // by a persistence layer such as a database or repository abstraction.
        private static readonly List<User> Users = new();

        /// <summary>
        /// Get the list of all users.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(Users);
        }

        /// <summary>
        /// Get a single user by ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<User> GetById(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(user);
        }

        /// <summary>
        /// Create a new user. Requires a valid API key in the X-Api-Key header.
        /// </summary>
        [HttpPost]
        public ActionResult<User> Create([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            newUser.Id = Guid.NewGuid();
            Users.Add(newUser);
            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        /// <summary>
        /// Update an existing user. Requires a valid API key in the X-Api-Key header.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<User> Update(Guid id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            // Update only fields that are provided
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;
            return Ok(user);
        }

        /// <summary>
        /// Delete a user. Requires a valid API key in the X-Api-Key header.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }
            Users.Remove(user);
            return Ok(user);
        }
    }
}