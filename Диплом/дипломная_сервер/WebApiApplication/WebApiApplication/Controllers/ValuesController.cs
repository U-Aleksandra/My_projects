using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AppDatabaseContext _adp;
        public ValuesController(AppDatabaseContext adp) 
        {
            _adp = adp;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public Array Get()
        {
            /*IEnumerable<User> users = _adp.Users.ToArray();
            UsersList usersList = new UsersList(users);*/
            Array users = _adp.Users.ToArray();
            return users;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            
            return _adp.Users.Find(id).Name;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(string name, string phone, string password, bool specialist)
        {
            User user = new User();

            user.Name = name;
            user.Phone = phone;
            user.Password = password;
            user.Specialist = specialist;

            _adp.Users.Add(user);
            _adp.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            User user = _adp.Users.Find(id);
            user.Name = name;
            _adp.SaveChanges();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _adp.Users.Find(id);
            _adp.Users.Remove(user);
            _adp.SaveChanges();
        }
    }
}
