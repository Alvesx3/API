using API.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class ChicaraContext : DbContext
    {
        public DbSet<Chicara> Chicaras { get; set; }
        public ChicaraContext(): base ("Data Source = 192.168.0.103; Initial Catalog = Categoria; Persist Security Info=True;User ID = a; Password=123")
        {

        }
    }
}
