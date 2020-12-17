using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        //now inside this class we have access to our database via dbcontext just by using undescore
        //context
        //add two end points
        // endpoint to get all the users
        // endpoint to get a specific user in our database

        // [HttpGet]
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // {
        //     return _context.Users.ToList();

        // }

        //api/users/3
        // [HttpGet("{id}")]
        // public ActionResult<AppUser> GetUser(int id)
        // {
        //     return _context.Users.Find(id);
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        /*
        IEnumerable allows us to use simple iteration over a collection of a specified type.
        List will do that same thing but it will return a list of users. But it also offers 
        methods to search, sort and manipulate list. Also offers too many features for what
        we are doing here but we just need a simple list that we can return to the client
        and IEnumerable is more appropriate type in this case.


        */


    }
}