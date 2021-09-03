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
    public class InventoryController : ControllerBase
    {
        [HttpGet]
        public List<Inventory> Get()
        {
            List<Inventory> list = new List<Inventory>();
            using (var context = new InventoryContext())
            {
                list = context.Inventory.ToList();
            }
            return list;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            Inventory model = new Inventory();
            using (var context = new InventoryContext())
            {
                model = context.Inventory.Find(id);
            }
            return model;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Inventory model)
        {
            using (var context = new InventoryContext())
            {
                context.Inventory.Add(model);
                context.SaveChanges();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Inventory model)
        {
            using (var context = new InventoryContext())
            {
                context.Entry<Inventory>(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        //// DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new InventoryContext())
            {
                context.Entry<Inventory>(Get(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
