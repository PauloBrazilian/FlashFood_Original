using FlashFood_Original.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FlashFood_Original
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base (options) 
        {
            public DbSet<Gerente> Gerentes { get; set; }
        }
    
    }
}
