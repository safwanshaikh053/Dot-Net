using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDataController : ControllerBase
    {
        private readonly EmpDbContext _dbContext;
        public EmpDataController(EmpDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/<EmpDataController>
        [HttpGet]
        public IEnumerable<Emp> Get()
        {
            return _dbContext.emps.ToList();
        }

        // GET api/<EmpDataController>/5
        [HttpGet("{id}")]
        public Emp Get(int id)
        {
            var empToBeFound = _dbContext.emps.FirstOrDefault(emp => emp.no == id);

            return empToBeFound;
        }

        // POST api/<EmpDataController>
        [HttpPost]
        public void Post([FromBody] Emp value)
        {
            _dbContext.emps.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/<EmpDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Emp value)
        {
            var empToBeUpdated = _dbContext.emps.FirstOrDefault(e => e.no == id);
            empToBeUpdated.name = value.name;
            empToBeUpdated.address = value.address;
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmpDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ep = _dbContext.emps.FirstOrDefault(ep=>ep.no==id);
            _dbContext.emps.Remove(ep);
            _dbContext.SaveChanges();
        }
    }
}
