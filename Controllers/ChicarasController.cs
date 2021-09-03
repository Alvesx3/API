using API.Context;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChicarasController : ControllerBase
    {
        [HttpGet]
        public List<Chicara> Get()
        {
            List<Chicara> list = new List<Chicara>();
            using(var context = new ChicaraContext())
            {
                list = context.Chicara.ToList();
            }
            return list;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Chicara Get(int id)
        {
            Chicara model = new Chicara();
            using (var context = new ChicaraContext())
            {
                model = context.Chicara.Find(id);
            }
            return model;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Chicara model)
        {
            using (var context = new ChicaraContext())
            {
                context.Chicara.Add(model);
                context.SaveChanges();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Chicara model)
        {
            using (var context = new ChicaraContext())
            {
                context.Entry<Chicara>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //// DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new ChicaraContext())
            {
                context.Entry<Chicara>(Get(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
